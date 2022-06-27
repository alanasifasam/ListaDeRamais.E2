using System;
using System.Collections.Generic;

#nullable disable

namespace ListaDeRamais.E2.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Departamentos = new HashSet<Departamento>();
        }

        public int CodigoEmpId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
