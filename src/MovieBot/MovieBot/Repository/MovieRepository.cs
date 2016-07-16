using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MovieBot.Repository
{
   
    public static class MovieRepository
    {
        static OMDBProvider omdbProvider;
        static MovieRepository()
        {
            omdbProvider = new OMDBProvider();
        }

        public static async Task<Movie> Get(string title)
        {
            var movie = await omdbProvider.Get(title);
            return movie as Movie;
        }

        public static async Task<OMDBMovieSearch> Search(string title)
        {
            // TODO : can be improved
            var movieSearch = await omdbProvider.Search(title);
            return movieSearch;
        }
    }
}