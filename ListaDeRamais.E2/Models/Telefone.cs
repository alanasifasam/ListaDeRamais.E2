using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ListaDeRamais.E2.Models
{
    public partial class Telefone
    {
        public Telefone()
        {
        }

        public int CodigoId { get; set; }
        public string NumeroTelefone { get; set; }

        [ForeignKey("Funcionario")]
        public int? CodigoFunFk { get; set; }
        public virtual Funcionario CodigoFunFkNavigation { get; set; }
    }
}
