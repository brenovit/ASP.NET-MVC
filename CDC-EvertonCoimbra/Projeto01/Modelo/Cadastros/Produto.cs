using Modelo.Tabela;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros
{
    public class Produto
    {
        public long? ProdutoID { get; set; }
        [DisplayName("Produto")]
        public string Nome { get; set; }

        public long? CategoriaID { get; set; }
        public long? FabricanteID { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}