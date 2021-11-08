using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe_Delegates
{
    public delegate void voitureDelegate(Voiture v);

    public class Carwash
    {
        private voitureDelegate traitement;
        public Carwash()
        {
            //avec méthodes nommées
            //traitement += Preparer;
            //traitement += Laver;
            //traitement += Secher;
            //traitement += Finaliser;

            //avec méthodes anonymes
            traitement = delegate (Voiture v)
            {
                Console.WriteLine($"je prépare la voiture : { v.Plaque } ");
            };
            traitement += delegate (Voiture v)
            {
                Console.WriteLine($"je lave la voiture :{ v.Plaque } ");
            };
            traitement += delegate (Voiture v)
            {
                Console.WriteLine($"je sèche la voiture : { v.Plaque } ");
            };
            traitement += delegate (Voiture v)
            {
                Console.WriteLine($"je finalise la voiture : { v.Plaque } ");
            };


        }
        private void Preparer(Voiture v)
        {
            Console.WriteLine($"je prépare la voiture : { v.Plaque } ");
        }
        private void Laver(Voiture v)
        {
            Console.WriteLine($"je lave la voiture :{ v.Plaque } ");
        }
        private void Secher(Voiture v)
        {
            Console.WriteLine($"je sèche la voiture : { v.Plaque } ");
        }
        private void Finaliser(Voiture v)
        {
            Console.WriteLine($"je finalise la voiture : { v.Plaque } ");
        }

        public void Traiter(Voiture v)
        {
            if(traitement != null)
            {
                traitement(v);
            }
        }

    }
}
