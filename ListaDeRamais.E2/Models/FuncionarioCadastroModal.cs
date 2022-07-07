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
        [Required(ErrorMessage ="Campo obrigatorio!!")]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage ="Campo obrigatório!!")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!!")]
        [EmailAddress]
        public string Email { get; set; }

        public int? CodigoFunFk { get; set; }
        public Funcionario CodigoFunFkNavigation { get; set; } = new Funcionario();



        
        public IList<Telefone> Telefones { get; set; } = new List<Telefone>();


       
        public virtual List<Ramais> CodigoRamalFkNavigation { get; set; } = new List<Ramais>();

        public int? CodigoRamalFk { get; set; }
        public int CodigoRamalId { get; set; }
        public  List<FunRamais> FunRamais { get; set; } = new List <FunRamais>();
        public int? NumeroRamal { get; set; }
       



   

        
       



    }
}
