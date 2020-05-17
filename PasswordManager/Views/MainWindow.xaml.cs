using PasswordsManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordsManager.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        private Boolean isEditionOpened;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            isEditionOpened = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int EditionColumnSize = 2;
            
            // Fleche.Source = new ImageSource("/PasswordsManager;component/assets/chevron_gauche.png";

            if(isEditionOpened)
            {
                EditionColumnSize = 0;
            }

            isEditionOpened = !isEditionOpened;
            Edition.Width = new GridLength(EditionColumnSize, GridUnitType.Star);
        }
    }
}
