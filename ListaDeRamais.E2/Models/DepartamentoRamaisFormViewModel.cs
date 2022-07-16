using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace ListaDeRamais.E2.Models
{
    public class DepartamentoRamaisFormViewModel
    {

        [Required(ErrorMessage ="Numero do Ramal é obrigatório !!")]
        [Range(3999,4999, ErrorMessage ="Ramais de 4000 a 4999")]
        public int NumeroRamal { get; set; }
        [Required(ErrorMessage ="Senha é obrigatório!!")]
        public string Senha { get; set; }
        [Required(ErrorMessage ="Endereço de IP é obrigatório !!")]
        [Range(1000,1000000, ErrorMessage ="Apenas os 5 últimos: 192.168.xxx-xx, não colocar pontuação")]
        public int HostIp { get; set; }
        public int CodigoRamalId { get; set; }
        public List<Ramais> Ramais { get; set; }

        [Required]
        public int? CodigoDepFk { get; set; }
        public List<Departamento> CodigoDepFkNavigation { get; set; } = new List<Departamento>();
       
        public string Nome { get; set; }
        public int CodigoDepId { get; set; }


        public int? CodigoRamalFk { get; set; }
        public virtual FunRamais FunRamais { get; set; }
    }

    
}


