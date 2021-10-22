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
        private Dictionary<string, Courant> _Comptes;
        public Dictionary<string, Courant> Comptes
        {
            get { return _Comptes = _Comptes ?? new Dictionary<string, Courant>(); }
        }
        public Courant this[string numero]
        {
            get
            {
                Courant cpt;
                Comptes.TryGetValue(numero, out cpt);
                return cpt;
            }
            set
            {
                if (value != null && value.Numero == numero)
                    Comptes[numero] = value;
            }
        }
        public void Ajouter(Courant compte)
        {
            if (compte != null)
                Comptes.Add(compte.Numero, compte);
        }
        public void Supprimer(string numero)
        {
            if (numero != null)
                Comptes.Remove(numero);
        }
        public double AvoirDesComptes(Personne titulaire)
        {
            if (titulaire == null)
                return 0;
            double result = 0;
            foreach(Courant cpt in Comptes.Values)
            {
                if (cpt.Titulaire == titulaire)
                    result = cpt + result;
            }
            return result;
        }

    }
}
