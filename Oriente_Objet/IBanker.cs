namespace Oriente_Objet
{
    interface IBanker : ICustomer
    {
        string Numero { get;  }
        Personne Titulaire { get;  }

        void AppliquerInteret();
    }
}