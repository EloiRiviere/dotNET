using System;
using System.Windows;
using System.Globalization;
using System.Collections.Generic;

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        MainViewModel mvm = new MainViewModel();
        Boolean resultatAffiche = false;
        List<KeyValuePair<string, string>> historique = new List<KeyValuePair<string, string>>();


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mvm;
        }

        // A l'évènement égale on calcule et on affiche le résultat
        private void Entrée_Click(object sender, RoutedEventArgs e) 
        {
            // gérer les caractères spéciaux
            resultatAffiche = true;

            string calcul = mvm.NbInUser;

            calcul = calcul.Replace(" ","");
            calcul = calcul.Replace("x", "*");
            calcul = calcul.Replace("√", "sqrt");
            calcul = calcul.Replace("²", "^2");
            calcul = calcul.Replace("%", "mod(");

            Console.WriteLine(calcul);

            org.mariuszgromada.math.mxparser.Expression exp = new org.mariuszgromada.math.mxparser.Expression(calcul);
            
            string resultat = Convert.ToString(exp.calculate());

            if(resultat.Equals("NaN"))
            {
                resultat = "Erreur de syntaxe";
                // resultat = "Erreur de syntaxe dans le calcul :\n" + calcul;
            }
            else
            {
                historique.Add(new KeyValuePair<string, string>(calcul, resultat));
                mvm.AffichagesHistorique = historiqueToString(historique);
                // Console.WriteLine(historique);
            }

            resultat = resultat.Replace(",", ".");

            mvm.StrAffichageTbx = resultat;

            // Console.WriteLine(calcul);
        }

        private string historiqueToString(List<KeyValuePair<string, string>> historique)
        {
            string valueHistoriqueToString = String.Empty;
            if (historique.Count >= 2)
            {
                string avantDernierCalcul = historique[historique.Count - 2].Key;
                string avantDernierResultat = historique[historique.Count - 2].Value;
                valueHistoriqueToString += avantDernierCalcul + "\n" + avantDernierResultat + "\n";
            }
            
            string DernierCalcul = historique[historique.Count - 1].Key;
            string DernierResultat = historique[historique.Count - 1].Value;

            valueHistoriqueToString += DernierCalcul + "\n" + DernierResultat;

            Console.WriteLine("Historique: " + valueHistoriqueToString);
            return valueHistoriqueToString;
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

        private void carre_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += "²";
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

        private void puissance_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += "^(";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void logarithme_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += "ln(";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void sinus_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += "sin(";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void cosinus_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += "cos(";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void tan_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += "tan(";
            mvm.StrAffichageTbx = String.Empty;
        }

        private void virgule_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += ".";
            mvm.StrAffichageTbx += ".";
        }

        private void OptimiseAffichage()
        {
            Console.WriteLine(mvm.StrAffichageTbx);
            CultureInfo FR = CultureInfo.CreateSpecificCulture("fr-FR");
            mvm.StrAffichageTbx = String.Format(FR, "{0:#,#}", Convert.ToString(mvm.StrAffichageTbx));
        }
    }
}
