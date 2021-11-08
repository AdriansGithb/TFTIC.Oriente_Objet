using System;

namespace Exe_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture v1 = new Voiture("1-ABC-001");
            Carwash crwsh = new Carwash();
            crwsh.Traiter(v1);

            Voiture v2 = new Voiture("2-ABC-002");
            crwsh.Traiter(v2);


        }
    }
}
