using MyMDb.Data;
using System.Linq;

namespace MyMDb.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext data;

        public StatisticsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public StatisticsServiceModel GetStatistics()
        {
            var moviesCount = this.data.Movies.Count();
            var totalLikies = this.data.UsersMovies.Count();
            var totalUsers = this.data.Users.Count();

            var statistics = new StatisticsServiceModel
            {
                TotalMovies = moviesCount,
                TotalLikes = totalLikies,
                TotalUsers = totalUsers,
            };

            return statistics;
        }
    }
}
