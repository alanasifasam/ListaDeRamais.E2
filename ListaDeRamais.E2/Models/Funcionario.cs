using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ListaDeRamais.E2.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
        }

        public int CodigoFunId { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!!")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!!")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!!")]
        [EmailAddress]
        public string Email { get; set; }
        public int? CodigoFunFk { get; set; }
        public virtual List<FunRamais> FunRamais { get; set; } = new List<FunRamais>();
        public IList<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
