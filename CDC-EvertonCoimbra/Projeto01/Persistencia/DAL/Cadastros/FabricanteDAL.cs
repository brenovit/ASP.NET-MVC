using Modelo.Cadastros;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Fabricante> ObterClassificadosPorNome()
        {
            return context.Fabricantes.OrderBy(b => b.Nome);
        }

        public Fabricante ObterPorId(long id)
        {
            return context.Fabricantes.Where(f => f.FabricanteID == id).Include("Produtos.Categoria").First();
        }

        public void Gravar(Fabricante fabricante)
        {
            if(fabricante.FabricanteID == null)
            {
                context.Fabricantes.Add(fabricante);
            }
            else
            {
                context.Entry(fabricante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Fabricante EliminarPorId(long id)
        {
            Fabricante fabricante = ObterPorId(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return fabricante;
        }
    }
}
