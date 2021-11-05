namespace Oriente_Objet
{
    interface ICustomer
    {
        double Solde { get; }

        void Depot(double montant);
        void Retrait(double montant, double ligneDeCredit = 0);
    }
}