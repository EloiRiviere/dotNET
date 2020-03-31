using System;
using System.Windows;
using System.Globalization;
using org.mariuszgromada.math.mxparser;

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        cls_Operations Ope = new cls_Operations();
        MainViewModel mvm = new MainViewModel();
        Boolean resultatAffiche = false;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mvm;
        }

        // A l'évènement égale on calcule et on affiche le résultat
        private void Entrée_Click(object sender, RoutedEventArgs e) 
        {
            // gérer le 'x' et le '√'
            resultatAffiche = true;
            Function fct = new Function("fct() = " + mvm.NbInUser);
            org.mariuszgromada.math.mxparser.Expression exp = new org.mariuszgromada.math.mxparser.Expression("fct()", fct);
            mvm.StrAffichageTbx = Convert.ToString(exp.calculate());
        }

        private void clicBtnNumero(char BtnContent)
        {
            if (resultatAffiche == true)
            {
                mvm.NbInUser = string.Empty;
                mvm.StrAffichageTbx = string.Empty;
                resultatAffiche = false;
            }
            mvm.NbInUser = mvm.NbInUser + BtnContent;
            mvm.StrAffichageTbx = mvm.StrAffichageTbx + BtnContent;
            OptimiseAffichage();
        }

        private void un_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('1');
        }

        private void deux_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('2');
        }

        private void trois_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('3');
        }

        private void quatre_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('4');
        }

        private void cinq_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('5');
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('6');
        }

        private void sept_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('7');
        }

        private void huit_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('8');
        }

        private void neuf_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('9');
        }

        private void zéro_Click(object sender, RoutedEventArgs e)
        {
            clicBtnNumero('0');
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser = String.Empty;
            mvm.StrAffichageTbx = String.Empty;
        }
        
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (mvm.StrAffichageTbx.Length > 0)
            {
                mvm.NbInUser = mvm.NbInUser.Remove(mvm.NbInUser.Length - 1, 1);
                mvm.StrAffichageTbx = mvm.StrAffichageTbx.Remove(mvm.StrAffichageTbx.Length - 1, 1);
            }
            OptimiseAffichage();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            mvm.NbInUser += " + ";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void moins_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            mvm.NbInUser += " - ";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void fois_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            mvm.NbInUser += " x ";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void par_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            mvm.NbInUser += " / ";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void modulo_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            mvm.NbInUser += " % ";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void racine_Click(object sender, RoutedEventArgs e)
        {
            //On sauvegarde les données de StrAffichageTbx dans autre tbx en rajoutant l'opérateur
            mvm.NbInUser += "√(";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void parenthèse_ouvrante_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += "(";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void parenthèse_fermante_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += ")";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void OptimiseAffichage() 
        {
            Console.WriteLine(mvm.StrAffichageTbx);
            CultureInfo FR = CultureInfo.CreateSpecificCulture("fr-FR");
            mvm.StrAffichageTbx = String.Format(FR, "{0:#,#}", Convert.ToDouble(mvm.StrAffichageTbx));
        }

    }
}
