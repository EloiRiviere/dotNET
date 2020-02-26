using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        cls_Operations ope = new cls_Operations();
        public event PropertyChangedEventHandler PropertyChanged;
        private Dictionary<string, object> _propertyValues = new Dictionary<string, object>();

        public string StrAffichageTbx
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (_propertyValues.ContainsKey(propertyName))
                return (T)_propertyValues[propertyName];
            return default(T);
        }
        public bool SetValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            var currentValue = GetValue<T>(propertyName);
            if (currentValue == null && newValue != null
             || currentValue != null && !currentValue.Equals(newValue))
            {
                _propertyValues[propertyName] = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        public MainWindow()
        {
            InitializeComponent();
            StrAffichageTbx = string.Empty;
            this.DataContext = this;
        }

        

        // A l'évènement égale on calcule et on affiche le résultat
        private void Entrée_Click(object sender, RoutedEventArgs e) 
        {

        }

        private void un_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '1';
        }

        private void deux_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '2';
        }

        private void trois_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '3';
        }

        private void quatre_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '4';
        }

        private void cinq_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '5';
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '6';
        }

        private void sept_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '7';
        }

        private void huit_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '8';
        }

        private void neuf_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '9';
        }

        private void zéro_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx + '0';
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = String.Empty;
        }
        
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            StrAffichageTbx = StrAffichageTbx.Remove(StrAffichageTbx.Length - 1, 1);
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            //AutreTbx.Text = StrAffichageTbx + ' ' + '+';
            StrAffichageTbx = String.Empty;
        }

        private void moins_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            //AutreTbx.Text = StrAffichageTbx + ' ' + '-';
            StrAffichageTbx = String.Empty;
        }

        private void fois_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            //AutreTbx.Text = StrAffichageTbx + ' ' + '*';
            StrAffichageTbx = String.Empty;
        }

        private void par_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            //AutreTbx.Text = StrAffichageTbx + ' ' + '/';
            StrAffichageTbx = String.Empty;
        }

        private void modulo_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            //AutreTbx.Text = StrAffichageTbx + ' ' + '%';
            StrAffichageTbx = String.Empty;
        }

        private void racine_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            //AutreTbx.Text = '√('+ StrAffichageTbx + ')';

            //On calcul directement car un seul nombre attendu et affichage
            StrAffichageTbx = Convert.ToString(ope.Racine(Convert.ToDouble(StrAffichageTbx)));
        }
    }
}
