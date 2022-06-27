using System;
using System.Collections.Generic;

#nullable disable

namespace ListaDeRamais.E2.Models
{
    public partial class FunRamais
    {
        public int Id { get; set; }
        public int? CodigoFunFk { get; set; }
        public virtual Funcionario CodigoFunFkNavigation { get; set; }

        public int? CodigoRamalFk { get; set; }
        public virtual Ramais CodigoRamalFkNavigation { get; set; } 
    }
}
