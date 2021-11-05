using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriente_Objet
{
    class Epargne : Compte
    {
        //public string Numero { get; set; }
        //public double Solde { get; private set; }
        public DateTime DateDernierRetrait { get; private set; }
        private const double tauxInteret = 0.45;

        public Epargne(string numero, Personne titulaire) 
            : base(numero, titulaire)
        {

        }
        public Epargne(string numero, Personne titulaire, double solde, DateTime dateDernierRetrait) 
            : base(numero, titulaire, solde)
        {
            this.DateDernierRetrait = dateDernierRetrait;
        }

        public override void Retrait(double montant, double ligneDeCredit = 0)
        {
            double ancienSolde = this.Solde;
            base.Retrait(montant);
            if (this.Solde != ancienSolde)
                this.DateDernierRetrait = DateTime.Now;
        }
        protected override double CalculInteret()
        {
            return this.Solde * tauxInteret;
        }

        //public Personne Titulaire { get; set; }

        //public void Retrait(double montant)
        //{
        //    if (montant < 0)
        //        return;
        //    else
        //    {
        //        double nwSolde = this.Solde - montant;
        //        if (nwSolde >= 0)
        //            this.Solde -= montant;
        //    }

        //}
        //public void Depot(double montant)
        //{
        //    if (montant <= 0) return;
        //    this.Solde += montant;
        //}
    }
}
