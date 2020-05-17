using System;

namespace Calculatrice
{
    class cls_Operations
    {
        public double Addition(double pPremierNombre, double pSecondNombre)
        {
            return pPremierNombre + pSecondNombre;
        }

        public double Soustraction(double pPremierNombre, double pSecondNombre)
        {
            return pPremierNombre - pSecondNombre;
        }

        public double Multiplication(double pPremierNombre, double pSecondNombre)
        {
            return pPremierNombre * pSecondNombre;
        }

        public object Division(double pPremierNombre, double pSecondNombre)
        {
            if (pSecondNombre == 0)
            {
                string Erreur = "Nous ne pouvons pas diviser par zéro";
                return Erreur;
            }
            else { return pPremierNombre / pSecondNombre; }
        }

        public double Carre(double pNombre)
        {
            return pNombre * pNombre;
        }

        public double Racine(double pPremierNombre)
        {
            return Math.Sqrt(pPremierNombre);
        }

        public object Cosinus(double pNombre)
        {
                return Math.Cos(pNombre);    
        }

        public object Sinus(double pNombre)
        {
                return Math.Sin(pNombre);
        }

        public double Tangente(double pNombre)
        {
            return Math.Tan(pNombre);
        }

        public double Logarithme(double pNombre)
        {
            return Math.Log(pNombre);
        }

        public double Puissance(double pNombre, double pPuissance)
        {
            return Math.Pow(pNombre, pPuissance);
        }

        public double Modulo(double pPremierNombre, double pSecondNombre)
        {
            return pPremierNombre % pSecondNombre;
        }
    }
}
