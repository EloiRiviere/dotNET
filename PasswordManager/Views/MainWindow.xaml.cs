using Microsoft.EntityFrameworkCore;
// using PasswordsManager.Converters;
using PasswordsManager.Models;
using PasswordsManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;


namespace PasswordsManager.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mvm;
        private Boolean isEditionOpened;
        private List<Password> listePasswords = new List<Password>();
        private static Boolean isModification = false;
        private static int EditionColumnSizeBase = 2;

        public MainWindow()
        {
            InitializeComponent();
            mvm = new MainViewModel();
            DataContext = mvm;

            isEditionOpened = false;
        }

        private void Button_Volet(object sender, RoutedEventArgs e)
        {
            int EditionColumnSize = 2;

            if (isEditionOpened)
            {
                EditionColumnSize = 0;
                Fleche.Source = new BitmapImage(new Uri("pack://application:,,,/PasswordsManager;component/assets/chevron_gauche.png"));
            }
            else
            {
                Fleche.Source = new BitmapImage(new Uri("pack://application:,,,/PasswordsManager;component/assets/chevron_droit.png"));
            }

            isEditionOpened = !isEditionOpened;
            Edition.Width = new GridLength(EditionColumnSize, GridUnitType.Star);
        }

        private void Recherche_SelectionChanged(object sender, RoutedEventArgs e)
        {
            /* Récupération de la chaîne de caractères de recherche */
            string recherche = Recherche.Text;

            Console.WriteLine("Evènement - Recherche - SelectionChanged : " + recherche);

            /* Mise à jour de la liste */
            mvm.listeSauvegarde = new ObservableCollection<Models.Password>();

            var l = DataAccess.PasswordsDbContext.Current.Passwords.Include(p => p.Tags).ThenInclude(pt => pt.Tag).ToList();


            /* Pour chaque mot de passe */
            foreach (var pass in l)
            {
                Console.WriteLine("pass.Label : " + pass.Label + " | pass.Label.IndexOf(recherche) : " + pass.Label.IndexOf(recherche));

                /* Si la recherche n'est pas vide */
                if (!recherche.Equals(String.Empty))
                {
                    /* Si il y a un match de la recherche dans le label du password */
                    if (pass.Label.IndexOf(recherche) >= 0)
                    {
                        mvm.listeSauvegarde.Add(pass);
                    }

                    /* 
                     * !!!
                     * 
                     * Ajouter cas de match avec tag, voir → PasswordsManager.Converters;
                     * 
                     * !!!
                     */
                }
                /* Si la recherche est vide, on affiche tous les password */
                else
                {
                    mvm.listeSauvegarde.Add(pass);
                }
            }

        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Console.WriteLine("Evènement - ListBox - SelectionChanged");
            ButtonSupprimer.Visibility = Visibility.Visible;
            ButtonModifier.Visibility = Visibility.Visible;

        }

        private void Formulaire_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Evènement - Formulaire - Validation : " + Recherche.Text);

            if (mvm.FormulaireLabel.Equals(String.Empty)
               || mvm.FormulaireMotDePasse.Equals(String.Empty)
               || mvm.FormulaireURL.Equals(String.Empty))
            {
                Console.WriteLine("Manque de données dans le formulaire : Label, Mot de passe ou Url.");
            }
            else
            {

                string encryptedPassword = Crypto.Encrypt(mvm.FormulaireMotDePasse);

                Password password = new Models.Password()
                {
                    Label = mvm.FormulaireLabel,
                    Login = mvm.FormulaireIdentifiant,
                    Pass = mvm.FormulaireMotDePasse,
                    Url = mvm.FormulaireURL
                };

                Tag tag = new Models.Tag()
                {
                    Label = mvm.FormulaireTags
                };

                password.Tags = new List<PasswordTag>();

                PasswordTag passwordTag = new PasswordTag()
                {
                    Tag = tag
                };

                if (isModification)
                {
                    Models.Password selectedPassword = (Models.Password)Liste_Passwords.SelectedItem;
                    mvm.listeSauvegarde.Remove(selectedPassword);
                    mvm.listeSauvegarde.Add(password);

                    DataAccess.PasswordsDbContext.Current.Remove(selectedPassword);
                    DataAccess.PasswordsDbContext.Current.Add(password);
                    try
                    {
                        DataAccess.PasswordsDbContext.Current.SaveChanges();
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException dbue) { };
                    Vider_Formulaire();
                    isModification = false;
                }
                else
                {
                    DataAccess.PasswordsDbContext.Current.Add(password);

                    Console.WriteLine("Password créé : " + password);

                    mvm.listeSauvegarde.Add(password);
                    Console.WriteLine(password);

                    // cryptage du mot de passe et mise en base
                    password.Pass = encryptedPassword;
                    DataAccess.PasswordsDbContext.Current.Add(password);
                }
            }
        }

        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            if(isModification)
            {
                isModification = false;
                Edition.Width = new GridLength(0, GridUnitType.Star);
                Vider_Formulaire();

            }
            Models.Password password = (Models.Password)Liste_Passwords.SelectedItem;
            DataAccess.PasswordsDbContext.Current.Remove(password);
            try
            {
                DataAccess.PasswordsDbContext.Current.SaveChanges();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException dbue) { };
            mvm.listeSauvegarde.Remove(password);

            if(isModification)
            {
                Vider_Formulaire();
            }

            ButtonSupprimer.Visibility = Visibility.Collapsed;
            ButtonModifier.Visibility = Visibility.Collapsed;
        }

        private void Button_Modifier(object sender, RoutedEventArgs e)
        {
            isModification = true;
            Models.Password password = (Models.Password)Liste_Passwords.SelectedItem;

            mvm.FormulaireLabel = password.Label;
            mvm.FormulaireIdentifiant = password.Login;
            // mvm.FormulaireMotDePasse = String.Empty;
            mvm.FormulaireMotDePasse = password.Pass;
            mvm.FormulaireURL = password.Url;

            String tags = String.Empty;

            foreach(PasswordTag pt in password.Tags)
            {
                tags += ", " + pt;
            }

            mvm.FormulaireTags = tags;

            Edition.Width = new GridLength(EditionColumnSizeBase, GridUnitType.Star);
            isEditionOpened = true;

            ButtonModifier.Visibility = Visibility.Collapsed;
        }

        private void Vider_Formulaire()
        {
            mvm.FormulaireLabel = String.Empty;
            mvm.FormulaireIdentifiant = String.Empty;
            mvm.FormulaireMotDePasse = String.Empty;
            mvm.FormulaireURL = String.Empty;
            mvm.FormulaireURL = String.Empty;
        }

        private void Formulaire_Button_Annuler_Click(object sender, RoutedEventArgs e)
        {
            if(isModification)
            {
                isModification = false;
            }
            Vider_Formulaire();
            ButtonModifier.Visibility = Visibility.Collapsed;
            ButtonSupprimer.Visibility = Visibility.Collapsed;
            Edition.Width = new GridLength(0, GridUnitType.Star);
            isEditionOpened = false;
        }
    }
}
