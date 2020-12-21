using Microsoft.EntityFrameworkCore;
using testeef.Models;
using testeef.Data;

namespace testeef.Data
{

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var _Category1 = new Category(2,"categoria 2");

            modelBuilder.Entity<Category>().HasData(_Category1);

/*
            var produto1 = new Product("produto teste 2", 5m, _Category1,"produto titulo 2" );
            produto1.Id = 2;
            produto1.Categoryid = 2;
            produto1.Category = null;

            modelBuilder.Entity<Product>().HasData(produto1);
*/
           // var fff = modelBuilder.Entity<Category>().AnyAsync<Category>();

           // CargaInicial.Inclui1produtoTeste(this);
           // var existeProduto = await this.Products.AnyAsync<Product>();

            // var qq = await this.Database.EnsureCreatedAsync();
        }

    }

}