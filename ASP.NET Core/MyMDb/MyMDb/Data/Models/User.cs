namespace MyMDb.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public int Age { get; set; }

        public IEnumerable<Movie> CreatedMovies { get; init; } = new HashSet<Movie>();

        public IEnumerable<UserMovie> UserMovies { get; init; } = new HashSet<UserMovie>();
    }
}
