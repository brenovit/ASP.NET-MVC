using Modelo.Cadastros;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    class FabricanteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Fabricante> ObterFabricanteClassificadosPorNome()
        {
            return context.Fabricantes.OrderBy(b => b.Nome);
        }
    }
}
