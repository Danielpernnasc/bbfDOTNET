using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


namespace bookstore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
            Console.WriteLine($"Environment: {env.EnvironmentName}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Bookstore API V1");
                });
            }
            else if (env.IsEnvironment("Homolog"))
            {
                app.UseDeveloperExceptionPage();

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

    }
}
