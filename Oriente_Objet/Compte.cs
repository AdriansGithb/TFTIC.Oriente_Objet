using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriente_Objet
{
    //delegate void PassageEnNegatifDelegate(Compte cpt);
    abstract class Compte : ICustomer, IBanker
    {
        //public event PassageEnNegatifDelegate PassageEnNegatifEvent;
        public Action<Compte> PassageEnNegatifEvent;


        public string Numero { get; private set; }
        public double Solde { get; private set; }
        public Personne Titulaire { get; private set; }
        //Si on ajoute LigneDeCredit à IBanker :
        //public virtual double LigneDeCredit
        //{
        //    get { return 0; }
        //    set { return; } // to do : implémenter erreur
        //}

        public Compte(string numero, Personne titulaire)
        {
            this.Numero = numero;
            this.Titulaire = titulaire;
        }
        public Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            this.Solde = solde;
        }

        public virtual void Retrait(double montant, double ligneDeCredit = 0)
        {
            try
            {
                if (montant < 0)
                    throw new ArgumentOutOfRangeException("Le montant doit être supérieur ou égal à 0");
                else
                {
                    if (this.Solde - montant >= -ligneDeCredit)
                    {
                        this.Solde -= montant;
                    }
                    else throw new SoldeInsuffisantException(); 
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            catch (SoldeInsuffisantException siex)
            {
                Console.WriteLine(siex.Message);
                return;
            }
        }
        public virtual void Depot(double montant)
        {
            try
            {
                if (montant < 0)
                    throw new ArgumentOutOfRangeException("Le montant doit être supérieur ou égal à 0");
                this.Solde += montant;
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
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
        protected abstract double CalculInteret();
        public void AppliquerInteret()
        {
            this.Solde += this.CalculInteret();
        }

        protected void RaisePassageEnNegatifEvent()
        {
            if (PassageEnNegatifEvent != null)
                PassageEnNegatifEvent(this);
        }
    }
}
