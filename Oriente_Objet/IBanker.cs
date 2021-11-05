namespace Oriente_Objet
{
    interface IBanker : ICustomer
    {
        string Numero { get; set; }
        Personne Titulaire { get; set; }

        void AppliquerInteret();
    }
}