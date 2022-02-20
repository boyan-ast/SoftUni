﻿namespace FootballManager
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    using FootballManager.Data;
    using FootballManager.Services;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<FootballManagerDbContext>()
                    .Add<IValidator, Validator>()
                    .Add<IUsersService, UsersService>()
                    .Add<IPlayersService, PlayersService>()
                    .Add<IPasswordHasher, PasswordHasher>()
                    .Add<IViewEngine, CompilationViewEngine>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
