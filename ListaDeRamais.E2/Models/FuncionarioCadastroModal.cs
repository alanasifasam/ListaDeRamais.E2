using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeRamais.E2.Models
{
    public class FuncionarioCadastroModal
    {
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
        public Funcionario CodigoFunFkNavigation { get; set; } = new Funcionario();



        [Required]
        public IList<Telefone> Telefones { get; set; } = new List<Telefone>();


       
        public virtual List<Ramais> CodigoRamalFkNavigation { get; set; } = new List<Ramais>();

        public int? CodigoRamalFk { get; set; }
        public int CodigoRamalId { get; set; }
        public  List<FunRamais> FunRamais { get; set; } = new List <FunRamais>();
        public int? NumeroRamal { get; set; }
       



   

        
       



    }
}
