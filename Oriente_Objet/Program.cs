using System;

namespace Oriente_Objet
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p1 = new Personne("Samuel","Legrain",new DateTime(1987, 9, 27));

            Courant c1 = new Courant("BE97 0000 0000 0000",200,p1);

            Console.WriteLine(c1);

            Console.WriteLine($"Compte N° {c1.Numero}\nTitulaire : {c1.Titulaire.Nom} {c1.Titulaire.Prenom} né en {c1.Titulaire.DateNaiss.Year}");
            Console.WriteLine($"Solde actuel : {c1.Solde}\tLigne de crédit : {c1.LigneDeCredit}");

            c1.Depot(500);

            Console.WriteLine($"Compte N° {c1.Numero}\nTitulaire : {c1.Titulaire.Nom} {c1.Titulaire.Prenom} né en {c1.Titulaire.DateNaiss.Year}");
            Console.WriteLine($"Solde actuel : {c1.Solde}\tLigne de crédit : {c1.LigneDeCredit}");

            c1.Retrait(1000);

            Console.WriteLine($"Compte N° {c1.Numero}\nTitulaire : {c1.Titulaire.Nom} {c1.Titulaire.Prenom} né en {c1.Titulaire.DateNaiss.Year}");
            Console.WriteLine($"Solde actuel : {c1.Solde}\tLigne de crédit : {c1.LigneDeCredit}");


            //TEST EXO02

            Banque auBonBillet = new Banque() { Nom = "Au bon Billet" };
            auBonBillet.Ajouter(c1);
            c1.Depot(100);
            auBonBillet.Ajouter(new Courant("BE87 0000 0000 0010" ,500,p1) );
            auBonBillet.Ajouter(null);


            Console.WriteLine($"Compte N° {auBonBillet["BE97 0000 0000 0000"].Numero}\nTitulaire : {auBonBillet["BE97 0000 0000 0000"].Titulaire.Nom} {auBonBillet["BE97 0000 0000 0000"].Titulaire.Prenom} né en {auBonBillet["BE97 0000 0000 0000"].Titulaire.DateNaiss.Year}");
            Console.WriteLine($"Solde actuel : {auBonBillet["BE97 0000 0000 0000"].Solde}\tLigne de crédit : {((Courant)auBonBillet["BE97 0000 0000 0000"]).LigneDeCredit}");

            //auBonBillet.Supprimer("BE97 0000 0000 0000");

            //Console.WriteLine($"Compte N° {auBonBillet["BE97 0000 0000 0000"].Numero}\nTitulaire : {auBonBillet["BE97 0000 0000 0000"].Titulaire.Nom} {auBonBillet["BE97 0000 0000 0000"].Titulaire.Prenom} né en {auBonBillet["BE97 0000 0000 0000"].Titulaire.DateNaiss.Year}");
            //Console.WriteLine($"Solde actuel : {auBonBillet["BE97 0000 0000 0000"].Solde}\tLigne de crédit : {auBonBillet["BE97 0000 0000 0000"].LigneDeCredit}");

            // Exos 03
            auBonBillet["BE87 0000 0000 0010"].Retrait(100);
            Console.WriteLine($"Avoir des comptes : {auBonBillet.AvoirDesComptes(p1)}");

            auBonBillet["BE87 0000 0000 0010"].AppliquerInteret();
            Console.WriteLine($"Avoir des comptes : {auBonBillet.AvoirDesComptes(p1)}");

            // Exceptions
            auBonBillet["BE87 0000 0000 0010"].Retrait(-100);
            Console.WriteLine($"Avoir des comptes : {auBonBillet.AvoirDesComptes(p1)}");
            auBonBillet["BE87 0000 0000 0010"].Depot(-100);
            Console.WriteLine($"Avoir des comptes : {auBonBillet.AvoirDesComptes(p1)}");
        }
    }
}
