using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriente_Objet
{
    class Compte
    {
        public string Numero { get; set; }
        public double Solde { get; private set; }
        public Personne Titulaire { get; set; }

        public virtual void Retrait(double montant, double ligneDeCredit = 0)
        {
            if (montant < 0)
                return;
            else
            {
                if (this.Solde - montant >= -ligneDeCredit)
                {
                    this.Solde -= montant;
                }
                else return ; // erreur a implémenter
            }
        }
        public virtual void Depot(double montant)
        {
            if (montant < 0)
                return;
            this.Solde += montant;
        }

    }
}
