using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable ObterClassificadosPorNome()
        {
            return fabricanteDAL.ObterClassificadosPorNome();
        }

        public Fabricante ObterPorId(long id)
        {
            return fabricanteDAL.ObterPorId(id);
        }

        public void Gravar(Fabricante fabricante)
        {
            fabricanteDAL.Gravar(fabricante);
        }

        public Fabricante EliminarPorId(long id)
        {
            return fabricanteDAL.EliminarPorId(id);
        }
    }
}
