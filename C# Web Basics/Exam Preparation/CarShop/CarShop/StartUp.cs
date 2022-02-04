using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using MyWebServer;
using MyWebServer.Controllers;
using MyWebServer.Results.Views;

using CarShop.Data;
using CarShop.Services;

namespace CarShop
{
    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IValidator, Validator>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IUserService, UserService>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
