﻿using System;
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
        public static double operator +(Compte cpt1, Compte cpt2)
        {
            double result = 0;
            if (cpt1.Solde >= 0)
                result += cpt1.Solde;
            if (cpt2.Solde >= 0)
                result += cpt2.Solde;
            return result;
        }
        public static double operator +(Compte cpt, double montant)
        {
            double result = 0;
            if (montant >= 0)
                result += cpt.Solde;
            if (cpt.Solde >= 0)
                result += montant;
            return result;
        }

    }
}
