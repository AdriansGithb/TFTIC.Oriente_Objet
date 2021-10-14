using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriente_Objet
{
    class Courant
    {
        public string Numero { get; set; }
        public double Solde { get; private set; }
        public Personne Titulaire { get; set; }
        public double _ligneDeCredit;
        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set
            {
                if (value >= 0)
                    _ligneDeCredit = value;
                else _ligneDeCredit = 0;
            }
        }

        public void Retrait(double montant)
        {
            if (montant < 0)
                return;
            else
            {
                double nwSolde = this.Solde - montant;
                if (nwSolde >= -LigneDeCredit)
                    this.Solde -= montant;
            }
        }
        public void Depot(double montant)
        {
            this.Solde += montant;
        }
        public static double operator +(Courant cpt, double montant)
        {
            double result = 0 ;
            if (montant >= 0)
                result += cpt.Solde;
            if (cpt.Solde >= 0)
                result += montant;
            return result;
        }
    }
}
