namespace MyMDb.Infrastructure
{
    using AutoMapper;
    using MyMDb.Data.Models;
    using MyMDb.Models.Movie;
    using MyMDb.Services.Movies.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Movie, MovieEditServiceModel>();
            this.CreateMap<MovieEditServiceModel, MovieFormModel>();
        }
    }
}
