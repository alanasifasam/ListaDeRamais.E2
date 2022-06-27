using System;
using System.Collections.Generic;

#nullable disable

namespace ListaDeRamais.E2.Models
{
    public partial class Ramais
    {
        public int CodigoRamalId { get; set; }
        public int NumeroRamal { get; set; }
        public string Senha { get; set; }
        public int HostIp { get; set; }

        
       
        

        public int? CodigoDepFk { get; set; }
        public virtual Departamento CodigoDepFkNavigation { get; set; }

        
        public virtual ICollection<FunRamais> FunRamais { get; set; }
    }
}
