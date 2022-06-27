using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ListaDeRamais.E2.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
           Ramais = new HashSet<Ramais>();
        }

        public int CodigoDepId { get; set; }
        [Required]
        public string Nome { get; set; }
        public int? CodigoEmpFk { get; set; }

        public virtual Empresa CodigoEmpFkNavigation { get; set; }

        
        public virtual ICollection<Ramais> Ramais { get; set; } 
    }
}
