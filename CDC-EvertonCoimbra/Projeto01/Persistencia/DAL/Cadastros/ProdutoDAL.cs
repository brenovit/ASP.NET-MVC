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
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Produto> ObterClassificadosPorNome()
        {
            return context.Produtos.OrderBy(b => b.Nome).Include(c => c.Categoria).Include(f => f.Fabricante);
        }

        public Produto ObterPorId(long id)
        {
            return context.Produtos.Where(p => p.ProdutoID == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
        }

        public void Gravar(Produto produto)
        {
            if(produto.ProdutoID == null)
            {
                context.Produtos.Add(produto);
            }else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Produto EliminarPorId(long id)
        {
            Produto produto = ObterPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }
    }
}
