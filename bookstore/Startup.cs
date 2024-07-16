<<<<<<< HEAD
﻿using bookstore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

=======
﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
namespace bookstore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
<<<<<<< HEAD
=======

>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

<<<<<<< HEAD
    
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookstoreDbContext>(options =>
              options.UseMySql(_configuration.GetConnectionString("DefaultConnection"),

                     new MySqlServerVersion(new Version(8, 0, 21))));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha Bookstore API", Version = "v1"});

            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
=======
        // Configuração dos serviços da aplicação
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do DbContext para o banco de dados
            services.AddDbContext<BookStoreContext>(options => 
            options.UseMySql(_configuration.GetConnectionString("DefaultConnection"),

                new MySqlServerVersion(new Version(8, 0, 21))));
        

            // Configuração dos controllers
            services.AddControllers();

            // Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha Bookstore API", Version = "v1" });
            });
        }

        // Configuração da pipeline de requisição HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Verifica se está em ambiente de desenvolvimento
>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

<<<<<<< HEAD
=======
                // Habilita o middleware do Swagger
>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha Bookstore API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
<<<<<<< HEAD

=======
>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
    }
}
