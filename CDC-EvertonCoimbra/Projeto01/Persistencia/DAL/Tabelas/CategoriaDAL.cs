using Modelo.Tabela;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();
        
        public IQueryable<Categoria> ObterClassificadasPorNome()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }

        public Categoria ObterPorId(long id)
        {
            return context.Categorias.Where(c => c.CategoriaID == id).Include("Produtos.Fabricante").First();
        }

        public void Gravar(Categoria categoria)
        {
            if (categoria.CategoriaID == null)
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Categoria EliminarPorId(long id)
        {
            Categoria categoria = ObterPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }

    }
}
