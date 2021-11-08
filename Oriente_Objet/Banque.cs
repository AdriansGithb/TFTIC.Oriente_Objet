using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriente_Objet
{
    class Banque
    {
        public string Nom { get; set; }
        private Dictionary<string, Compte> _Comptes;
        public Dictionary<string, Compte> Comptes
        {
            get { return _Comptes = _Comptes ?? new Dictionary<string, Compte>(); }
        }
        public Compte this[string numero]
        {
            get
            {
                Compte cpt;
                Comptes.TryGetValue(numero, out cpt);
                return cpt;
            }
            set
            {
                if (value != null && value.Numero == numero)
                    Comptes[numero] = value;
            }
        }
        public void Ajouter(Compte compte)
        {
            if (compte != null)
            {
                Comptes.Add(compte.Numero, compte);
                compte.PassageEnNegatifEvent += PassageEnNegatifAction;
            }
        }
        public void Supprimer(string numero)
        {
            
            if (numero != null)
            {
                Compte cpt = this[numero];
                if (cpt != null)
                {
                    cpt.PassageEnNegatifEvent -= PassageEnNegatifAction;
                    Comptes.Remove(numero);
                }
            }
        }
        public double AvoirDesComptes(Personne titulaire)
        {
            if (titulaire == null)
                return 0;
            double result = 0;
            foreach(Compte cpt in Comptes.Values)
            {
                if (cpt.Titulaire == titulaire)
                    result = cpt + result;
            }
            return result;
        }

        private void PassageEnNegatifAction(Compte cpt)
        {
            Console.WriteLine($"Le compte {cpt.Numero} vient de passer en négatif");
        }
    }
}
