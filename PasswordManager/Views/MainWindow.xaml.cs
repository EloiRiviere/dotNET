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

        public MainWindow()
        {
            InitializeComponent();
            mvm = new MainViewModel();
            DataContext = mvm;

            isEditionOpened = false;

            /*
            var t = new Models.Tag()
            {
                Label = "tag"
            };

            var p = new Models.Password()
            {
                Label = "label1",
                Login = "login1",
                Pass = "pass1",
                Url = "url1"
            };

            p.Tags = new List<PasswordTag>();
            p.Tags.Add(new PasswordTag()
            {
                Tag = t
            });

            mvm.listeSauvegarde = new System.Collections.ObjectModel.ObservableCollection<Password>();
            mvm.listeSauvegarde.Add(p);
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        }

        private void Formulaire_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Evènement - Formulaire - Validation : " + Recherche.Text);

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

            DataAccess.PasswordsDbContext.Current.Add(password);

            Console.WriteLine("Password créé : " + password);

            mvm.listeSauvegarde.Add(password);
            Console.WriteLine(password);

            // cryptage du mot de passe et mise en base
            password.Pass = encryptedPassword;
            DataAccess.PasswordsDbContext.Current.Add(password);
        }

        private void Button_Supprimer(object sender, RoutedEventArgs e)
        {
            Models.Password password = (Models.Password)Liste_Passwords.SelectedItem;
            DataAccess.PasswordsDbContext.Current.Remove(password);
            DataAccess.PasswordsDbContext.Current.SaveChanges();
            mvm.listeSauvegarde.Remove(password);
            ButtonSupprimer.Visibility = Visibility.Collapsed;
        }
    }
}
