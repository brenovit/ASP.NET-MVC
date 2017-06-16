using Modelo.Tabela;
using Persistencia.DAL.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable ObterClassificadasPorNome()
        {
            return categoriaDAL.ObterClassificadasPorNome();
        }

        public Categoria ObterPorId(long id)
        {
            return categoriaDAL.ObterPorId(id);
        }

        public void Gravar(Categoria categoria)
        {
            categoriaDAL.Gravar(categoria);
        }

        public Categoria EliminarPorId(long id)
        {
            return categoriaDAL.EliminarPorId(id);
        }

    }
}
