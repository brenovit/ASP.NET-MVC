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
    class ProdutoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Produto> ObterProdutoClassificadosPorNome()
        {
            return context.Produtos.OrderBy(b => b.Nome);
        }

        public Produto ObterProdutoPorId(long id)
        {
            return context.Produtos.Where(p => p.ProdutoID == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();
        }

        public void GravarProduto(Produto produto)
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

        public Produto EliminarProdutoPorId(long id)
        {
            Produto produto = ObterProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }
    }
}
