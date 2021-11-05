using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriente_Objet
{
    class Courant : Compte
    {
        //public string Numero { get; set; }
        //public double Solde { get; private set; }
        //public Personne Titulaire { get; set; }

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
        private const double tauxIntPos = 0.03;
        private const double tauxIntNeg = 0.0975;

        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {

        }
        public Courant(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {

        }

        public Courant(string numero, double ligneDeCredit, Personne titulaire) : base(numero, titulaire)
        {
            this.LigneDeCredit = ligneDeCredit;
        }
        public override void Retrait(double montant, double ligneDeCredit=0)
        {
            base.Retrait(montant, this.LigneDeCredit);
        }
        protected override double CalculInteret()
        {
            if (this.Solde >= 0)
                return this.Solde * tauxIntPos;
            else return this.Solde * tauxIntNeg;
        }
        //public void Depot(double montant)
        //{
        //    this.Solde += montant;
        //}

        //public static double operator +(Courant cpt1, Courant cpt2)
        //{
        //    double result = 0;
        //    if (cpt1.Solde >= 0)
        //        result += cpt1.Solde;
        //    if (cpt2.Solde >= 0)
        //        result += cpt2.Solde;
        //    return result;
        //}
        //public static double operator +(Courant cpt, double montant)
        //{
        //    double result = 0 ;
        //    if (montant >= 0)
        //        result += cpt.Solde;
        //    if (cpt.Solde >= 0)
        //        result += montant;
        //    return result;
        //}
    }
}
