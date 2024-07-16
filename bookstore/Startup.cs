using bookstore.Data;
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
            if (env.IsDevelopment())
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
