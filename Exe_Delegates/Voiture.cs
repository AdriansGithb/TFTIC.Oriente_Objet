using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe_Delegates
{
    public class Voiture
    {
        public string Plaque { get; private set; }

        public Voiture(string plaque)
        {
            this.Plaque = plaque;
        }
    }
}
