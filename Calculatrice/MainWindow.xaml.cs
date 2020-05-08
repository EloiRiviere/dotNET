using System;
using System.Windows;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

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

            /*
            KeyEventArgs eventKeyUpEnter = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Enter);
            eventKeyUpEnter.RoutedEvent = Keyboard.KeyDownEvent;
            InputManager.Current.ProcessInput(eventKeyUpEnter);
            */
        }
        /*
        private void testEnter(object sender, KeyEventArgs eventKeyUpEnter)
        {
            Console.WriteLine("La grosse bite en plâtre.");
        }
        */

        // A l'évènement égale on calcule et on affiche le résultat
        private void Entrée_Click(object sender, RoutedEventArgs e) 
        {
            // gérer les caractères spéciaux
            resultatAffiche = true;

            string calculUtilisateur = mvm.NbInUser;
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
                historique.Add(new KeyValuePair<string, string>(calculUtilisateur, resultat));
                mvm.AffichagesHistoriqueCalcAD = historiqueToString(historique)[0];
                mvm.AffichagesHistoriqueResAD = historiqueToString(historique)[1];
                mvm.AffichagesHistoriqueCalcD = historiqueToString(historique)[2];
                mvm.AffichagesHistoriqueResD = historiqueToString(historique)[3];

                Console.WriteLine(mvm.historiqueObservable);

                mvm.historiqueObservable.Add(calculUtilisateur);
                mvm.historiqueObservable.Add(resultat);

                // Console.WriteLine(historique);
            }

            resultat = resultat.Replace(",", ".");

            mvm.StrAffichageTbx = resultat;

            // Console.WriteLine(calcul);
        }

        private List<string> historiqueToString(List<KeyValuePair<string, string>> historique)
        {
            string valueHistoriqueToString = String.Empty;
            string avantDernierCalcul = String.Empty;
            string avantDernierResultat = String.Empty;

            if (historique.Count >= 2)
            {
                avantDernierCalcul = historique[historique.Count - 2].Key;
                avantDernierResultat = historique[historique.Count - 2].Value;
                valueHistoriqueToString += avantDernierCalcul + "\n" + avantDernierResultat + "\n";
            }
            
            string DernierCalcul = historique[historique.Count - 1].Key;
            string DernierResultat = historique[historique.Count - 1].Value;

            valueHistoriqueToString += DernierCalcul + "\n" + DernierResultat;

            Console.WriteLine("Historique: " + valueHistoriqueToString);
            //return valueHistoriqueToString;
            return new List<string> { avantDernierCalcul, avantDernierResultat, DernierCalcul, DernierResultat };
        }
        private void clicBtnNumero(char BtnContent)
        {
            if (resultatAffiche == true)
            {
                mvm.NbInUser = String.Empty;
                mvm.StrAffichageTbx = String.Empty;
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

        private void clickBtnOperation()
        {
            if (resultatAffiche == true)
            {
                mvm.NbInUser = mvm.StrAffichageTbx;
                resultatAffiche = false;
            }
            mvm.StrAffichageTbx = String.Empty;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += " + ";
        }

        private void moins_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += " - ";
        }

        private void fois_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += " x ";
        }

        private void par_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += " / ";
        }

        private void modulo_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += " % ";
        }

        private void racine_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "√(";
        }

        private void carre_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "²";
        }

        private void parenthèse_ouvrante_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "(";
        }

        private void parenthèse_fermante_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += ")";
        }

        private void puissance_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "^(";
        }

        private void logarithme_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "ln(";
        }

        private void sinus_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "sin(";
        }

        private void cosinus_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "cos(";
        }

        private void tan_Click(object sender, RoutedEventArgs e)
        {
            clickBtnOperation();
            mvm.NbInUser += "tan(";
        }

        private void virgule_Click(object sender, RoutedEventArgs e)
        {
            mvm.NbInUser += ".";
            mvm.StrAffichageTbx += ".";
        }

        private void history_Click_Up(object sender, RoutedEventArgs e)
        {
            Historique.Visibility = Visibility.Visible;

            for(int i = 0 ; i < ListeHistorique.Items.Count; i = i + 2)
            {
                //ListeHistorique.Items.GetItemAt(i).HorizontalAlignment = HorizontalAlignment.Right;
            }
        }

        private void history_Click_Down(object sender, RoutedEventArgs e)
        {
            Historique.Visibility = Visibility.Collapsed;
        }

        private void OptimiseAffichage()
        {
            Console.WriteLine(mvm.StrAffichageTbx);
            CultureInfo FR = CultureInfo.CreateSpecificCulture("fr-FR");
            mvm.StrAffichageTbx = String.Format(FR, "{0:#,#}", Convert.ToString(mvm.StrAffichageTbx));
        }

        private void ListeHistorique_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                mvm.StrAffichageTbx = ListeHistorique.SelectedItem.ToString();
                mvm.NbInUser = ListeHistorique.SelectedItem.ToString();
                resultatAffiche = false;
            }
            // Gérer exception si on vide l'historique
            catch(System.NullReferenceException)
            {
                Console.WriteLine("Historique vidé.");
            }
        }

        private void history_Empty(object sender, RoutedEventArgs e)
        {
            // Nettoyer historique
            mvm.historiqueObservable.Clear();

            // Nettoyer affichage bouton historique
            historique.Clear();
            mvm.AffichagesHistoriqueCalcAD = String.Empty;
            mvm.AffichagesHistoriqueResAD = String.Empty;
            mvm.AffichagesHistoriqueCalcD = String.Empty;
            mvm.AffichagesHistoriqueResD = String.Empty;
        }
    }
}
