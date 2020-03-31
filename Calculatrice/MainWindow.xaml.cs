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
using System.Globalization;

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        cls_NotifyPropertyChanged ObjComplexe = new cls_NotifyPropertyChanged();
        cls_Operations Ope = new cls_Operations();
        int NbEspace = 0;
        string NbInUser = "";

        public string StrAffichageTbx
        {
            get { return ObjComplexe.GetValue<string>(); }
            set { ObjComplexe.SetValue(value); }
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
            NbInUser = NbInUser + '1';
            StrAffichageTbx = StrAffichageTbx + '1';
            OptimiseAffichage();
            MessageBox.Show(StrAffichageTbx);
        }

        private void deux_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '2';
            StrAffichageTbx = StrAffichageTbx + '2';
            //MessageBox.Show(StrAffichageTbx);
        }

        private void trois_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '3';
            StrAffichageTbx = StrAffichageTbx + '3';
            //MessageBox.Show(StrAffichageTbx);
        }

        private void quatre_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '4';
            StrAffichageTbx = StrAffichageTbx + '4';
        }

        private void cinq_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '5';
            StrAffichageTbx = StrAffichageTbx + '5';
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '6';
            StrAffichageTbx = StrAffichageTbx + '6';
        }

        private void sept_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '7';
            StrAffichageTbx = StrAffichageTbx + '7';
        }

        private void huit_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '8';
            StrAffichageTbx = StrAffichageTbx + '8';
        }

        private void neuf_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '9';
            StrAffichageTbx = StrAffichageTbx + '9';
            OptimiseAffichage();
            MessageBox.Show(StrAffichageTbx);
        }

        private void zéro_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = NbInUser + '0';
            StrAffichageTbx = StrAffichageTbx + '0';
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            NbInUser = String.Empty;
            StrAffichageTbx = String.Empty;
        }
        
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (StrAffichageTbx.Length > 0)
            {
                NbInUser = StrAffichageTbx.Remove(StrAffichageTbx.Length - 1, 1);
                StrAffichageTbx = StrAffichageTbx.Remove(StrAffichageTbx.Length - 1, 1);
            }
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
            StrAffichageTbx = Convert.ToString(Ope.Racine(Convert.ToDouble(StrAffichageTbx)));
        }

        private void OptimiseAffichage() 
        {
            //double ResultatMod = Ope.Modulo(NbInUser.Length, 3);
            ////S'il y a au minimum 4 caractères dans la chaîne on la réorganise
            //if (NbInUser.Length > 3)
            //{
            //    switch (ResultatMod)
            //    {
            //        case 1:
            //            if (NbInUser.Length > 4)
            //            {
            //                StrAffichageTbx = StrAffichageTbx.Remove(3, 1);
            //            }
            //            StrAffichageTbx = StrAffichageTbx.Insert(1, " ");
            //            NbEspace++;
            //            break;
            //        case 2:
            //            //On retire l'espace situé en position 1
            //            StrAffichageTbx = StrAffichageTbx.Remove(1, 1);
            //            StrAffichageTbx = StrAffichageTbx.Insert(2, " ");
            //            NbEspace++;
            //            break;
            //        case 0:
            //            //On retire l'espace situé en position 2
            //            StrAffichageTbx = StrAffichageTbx.Remove(2, 1);
            //            StrAffichageTbx = StrAffichageTbx.Insert(3, " ");
            //            NbEspace++;
            //            break;
            //    }

            //}
            CultureInfo FR = CultureInfo.CreateSpecificCulture("fr-FR");
            StrAffichageTbx = String.Format(FR, "{0:0,0}", Convert.ToDouble(StrAffichageTbx));
        }
    }
}
