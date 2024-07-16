<<<<<<< HEAD
=======
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
namespace bookstore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
<<<<<<< HEAD

=======
>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
<<<<<<< HEAD
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();


            });
    }

}
=======
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
>>>>>>> a84e7b30727f784cac4959528ad35dc87342afda
