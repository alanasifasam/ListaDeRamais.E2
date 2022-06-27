using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeRamais.E2.Models
{
    public class VincularViewModel
    {
        

        public int? CodigoFunFk { get; set; }
        public virtual List<Funcionario> CodigoFunFkNavigation { get; set; } = new List<Funcionario>();
        public string Nome { get; set; }



        public int? CodigoRamalFk { get; set; }
        public virtual List<Ramais> CodigoRamalFkNavigation { get; set; } = new List<Ramais>();
        public int? NumeroRamal { get; set; }

    }
}
