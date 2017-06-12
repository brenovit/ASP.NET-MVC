using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros
{
    public class Fabricante
    {        
        public long FabricanteID { get; set; }
        [DisplayName("Fabricante")]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}