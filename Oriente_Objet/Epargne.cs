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
        public DateTime DateDernierRetrait { get; set; }

        public override void Retrait(double montant, double ligneDeCredit = 0)
        {
            double ancienSolde = this.Solde;
            base.Retrait(montant);
            if (this.Solde != ancienSolde)
                this.DateDernierRetrait = DateTime.Now;
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
