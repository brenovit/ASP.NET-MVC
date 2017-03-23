using Projeto01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto01.Context
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CD") {
            Database.SetInitializer<EFContext>(new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}