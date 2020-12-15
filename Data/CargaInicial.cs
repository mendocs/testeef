
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using testeef.Models;


namespace testeef.Data
{
    public class CargaInicial: ControllerBase
    {
        public void Inclui1produtoTeste(DataContext  context)//[FromServices] DataContext  context)
        {


             
            //var log = (DataContext)services .GetService(typeof(DataContext));
            //produto 1
            var _Category1 = new Category(1,"categoria 11");

            var _Category2 = new Category(2,"categoria 22");
        
        
            context.Categories.Add(_Category1);
            context.Categories.Add(_Category2);

            var produto1 = new Product("produto teste 1", 5m, _Category1,"produto 11" );
            var produto2 = new Product("produto teste 2", 5m, _Category2 ,"produto 22");
            

            context.Products.Add(produto1);
            context.Products.Add(produto2);
            context.SaveChanges();
            //await context.SaveChangesAsync();

        }        
    }
}