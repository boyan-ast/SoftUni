namespace Git
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using Git.Data;
    using Git.Services;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<ApplicationDbContext>()
                    .Add<IValidator, Validator>()
                    .Add<IUsersService, UsersService>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IRepositoryService, RepositoryService>()
                    .Add<ICommitsService, CommitsService>()
                    .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<ApplicationDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
