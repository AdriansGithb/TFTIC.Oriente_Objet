using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oriente_Objet
{
    public class SoldeInsuffisantException : Exception
    {

        public SoldeInsuffisantException() : base("Solde insuffisant !")
        {
        }
    }
}
