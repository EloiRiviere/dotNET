﻿using System;
using System.Windows;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Windows.Input;

namespace Calculatrice
{
    public partial class MainWindow
    {
        MainViewModel mvm = new MainViewModel();
        Boolean resultatAffiche = false;

        // const string cheminFichierBinaireHistorique = @"../../sauvegarde_historique";
        List<KeyValuePair<string, string>> historique = new List<KeyValuePair<string, string>>();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mvm;

            /* Persistance
            // Chargement de l'historique
            using (Stream stream = File.Open(cheminFichierBinaireHistorique, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, historique);
            }
            */
        }

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

        private void zero_Click(object sender, RoutedEventArgs e)
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
            if (resultatAffiche == true)
            {
                resultatAffiche = false;
            }
        }

        private void history_Click_Up(object sender, RoutedEventArgs e)
        {
            Historique.Visibility = Visibility.Visible;

            /* // Aligner les résultats à droite
            for(int i = 0 ; i < ListeHistorique.Items.Count; i = i + 2)
            {
                //ListeHistorique.Items.GetItemAt(i).HorizontalAlignment = HorizontalAlignment.Right;
            }
            */
        }

        private void history_Click_Down(object sender, RoutedEventArgs e)
        {
            Historique.Visibility = Visibility.Collapsed;
        }

        private void OptimiseAffichage()
        {
            Console.WriteLine(mvm.StrAffichageTbx);
            CultureInfo FR = CultureInfo.CreateSpecificCulture("fr-FR");

            // Erreur formatteur, arrondit le résultat
            // mvm.StrAffichageTbx = Convert.ToDouble(mvm.StrAffichageTbx.Replace(".", ",")).ToString("#,##0", new CultureInfo("fr-FR"));

            // Erreur formatteur, ne fonctionne pas
            // mvm.StrAffichageTbx = string.Format(FR, "{0:#.#}", Convert.ToString(mvm.StrAffichageTbx));

            
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

        /* Persistance
        List<KeyValuePair<string, string>> MainWindow_Closing(object sender, CancelEventArgs e)
        {
            using (Stream stream = File.Open(cheminFichierBinaireHistorique, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (List<KeyValuePair<string, string>>)binaryFormatter.Deserialize(stream);
            }
        }
        */

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    zero_Click(sender, e);
                    break;
                case Key.NumPad1:
                    un_Click(sender, e);
                    break;
                case Key.NumPad2:
                    deux_Click(sender, e);
                    break;
                case Key.NumPad3:
                    trois_Click(sender, e);
                    break;
                case Key.NumPad4:
                    quatre_Click(sender, e);
                    break;
                case Key.NumPad5:
                    cinq_Click(sender, e);
                    break;
                case Key.NumPad6:
                    six_Click(sender, e);
                    break;
                case Key.NumPad7:
                    sept_Click(sender, e);
                    break;
                case Key.NumPad8:
                    huit_Click(sender, e);
                    break;
                case Key.NumPad9:
                    neuf_Click(sender, e);
                    break;
                case Key.Divide:
                   par_Click(sender, e);
                    break;
                case Key.Multiply:
                    fois_Click(sender, e);
                    break;
                case Key.Add:
                    plus_Click(sender, e);
                    break;
                case Key.Subtract:
                    moins_Click(sender, e);
                    break;
                case Key.Return:
                    Entrée_Click(sender, e);
                    break;
                case Key.OemQuotes:
                    carre_Click(sender, e);
                    break;
                case Key.D5:
                    parenthèse_ouvrante_Click(sender, e);
                    break;
                case Key.OemOpenBrackets:
                    parenthèse_fermante_Click(sender, e);
                    break;
                case Key.L:
                    logarithme_Click(sender, e);
                    break;
                case Key.R:
                    racine_Click(sender, e);
                    break;
                case Key.M:
                    modulo_Click(sender, e);
                    break;
                case Key.Oem6:
                    puissance_Click(sender, e);
                    break;
                case Key.S:
                    sinus_Click(sender, e);
                    break;
                case Key.C:
                    cosinus_Click(sender, e);
                    break;
                case Key.T:
                    tan_Click(sender, e);
                    break;
                case Key.Decimal:
                    virgule_Click(sender, e);
                    break;
                case Key.Back:
                    delete_Click(sender, e);
                    break;
                case Key.Delete:
                    clear_Click(sender, e);
                    break;
                default:
                    Console.WriteLine("Touche inconnue");
                    break;
                
            }
            Console.WriteLine(e.Key);
        }
    }
}
