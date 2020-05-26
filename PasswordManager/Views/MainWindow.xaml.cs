using PasswordsManager.Models;
using System;
using System.Collections.Generic;
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
            Console.WriteLine("Evènement - Recherche - SelectionChanged : " + Recherche.Text);
        }

        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Formulaire_Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Evènement - Formulaire - Validation : " + Recherche.Text);

            // listePasswords.Add(new Password());
        }
    }
}
