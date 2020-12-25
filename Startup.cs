using System.Net.Mime;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using testeef.Data;
using Microsoft.AspNetCore.Http;
using testeef.Models;

namespace testeef
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

             //services.AddDbContext<DataContext> (opt => opt.UseInMemoryDatabase ("Database"));
             services.AddDbContext<DataContext> (opt => opt.UseSqlServer (Configuration.GetConnectionString("DefaultConnection")));

            
            
            services.AddScoped<DataContext,DataContext>();

            

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers();

            services.AddSwaggerGen();

            //var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void  Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext datacontext)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });            



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors("EnableCORS");

          

            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            /*
            var ttt = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<DataContext>();
            var uuu= ttt.UseInMemoryDatabase("Database1").Options;
            //DbContextOptions<DataContext>
            var datacontext1 = new DataContext(uuu);
            */
            

            //var servico = context.RequestServices.GetService<DataContext>();

            //var qq =  datacontext.Database.EnsureCreatedAsync();

            //var existeProduto = await datacontext.Products.AnyAsync<Product>();

            //CargaInicial cargaInicial = new CargaInicial();
            //cargaInicial.Inclui1produtoTeste(datacontext);

            //CargaInicial.Inclui1produtoTeste(datacontext);


        }
    }
}
