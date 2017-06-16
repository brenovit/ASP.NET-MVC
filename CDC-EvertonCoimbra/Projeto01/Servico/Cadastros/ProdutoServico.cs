using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();

        public IQueryable ObterClassificadosPorNome()
        {
            return produtoDAL.ObterClassificadosPorNome();
        }

        public Produto ObterPorId(long id)
        {
            return produtoDAL.ObterPorId(id);
        }

        public void Gravar(Produto produto)
        {
            produtoDAL.Gravar(produto);
        }

        public Produto EliminarPorId(long id)
        {
            return produtoDAL.EliminarPorId(id);
        }
    }
}
