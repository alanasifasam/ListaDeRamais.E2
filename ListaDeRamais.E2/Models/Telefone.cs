using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Campo obrigatório!!")]
        [RegularExpression(@"\([0-9]{2}\) 9?[0-9]{4}-[0-9]{4}$",
        ErrorMessage = "(xx) 9xxxx-xxxx")]
        public string NumeroTelefone { get; set; }



        [ForeignKey("Funcionario")]
        public int? CodigoFunFk { get; set; }
        public virtual Funcionario CodigoFunFkNavigation { get; set; }
    }
}
