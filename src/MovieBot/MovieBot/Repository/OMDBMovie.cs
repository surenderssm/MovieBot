using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBot.Repository
{

    public class OMDBMovieSearch
    {
        public Search[] Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }

    public class Search
    {
        public string Title { get; set; }
        [ViewIgnore]
        public string Year { get; set; }
        [ViewIgnore]
        public string imdbID { get; set; }
        public string Type { get; set; }
        [ViewIgnore]
        public string Poster { get; set; }
    }

    public class OMDBMovie : Movie
    {
        //public string Title { get; set; }
        //public string imdbRating { get; set; }
        //public string imdbVotes { get; set; }
        ////public string Year { get; set; }
        //public string Rated { get; set; }
        //public string Released { get; set; }
        //public string Runtime { get; set; }
        //public string Genre { get; set; }
        //public string Director { get; set; }
        //public string Writer { get; set; }
        //public string Actors { get; set; }
        //public string Plot { get; set; }
        //public string Language { get; set; }
        //public string Country { get; set; }
        //public string Awards { get; set; }
        //public string Poster { get; set; }
        //public string Metascore { get; set; }
        ////public string imdbRating { get; set; }
        ////public string imdbVotes { get; set; }
        ////public string imdbID { get; set; }
        ////public string Type { get; set; }
        ////public string Response { get; set; }

    }
}