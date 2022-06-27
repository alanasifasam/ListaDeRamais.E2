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
           // FunRamais = new HashSet<FunRamais>();
           
          // Telefones = new List<Telefone>();
        }

        public int CodigoFunId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public int? CodigoFunFk { get; set; }

        public virtual List<FunRamais> FunRamais { get; set; } = new List<FunRamais>();
        
       
        [Required]
        public IList<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
