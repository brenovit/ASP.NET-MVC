using Modelo.Tabela;
using Modelo.Cadastros;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Banco") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilde)
        {
            base.OnModelCreating(modelBuilde);
            modelBuilde.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}