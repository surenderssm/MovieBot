using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBot.Repository
{
    public class Movie
    {
        [ImageUri]
        public string Poster { get; set; }
        public string Title { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string Awards { get; set; }
        public string Plot { get; set; }

        [ViewIgnore]
        public string Year { get; set; }
        [ViewIgnore]
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        [ViewIgnore]
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Language { get; set; }

        [ViewIgnore]
        public string Country { get; set; }

        [ViewIgnore]
        public string Metascore { get; set; }
        [ViewIgnore]
        public string imdbID { get; set; }
        [ViewIgnore]
        public string Type { get; set; }
        [ViewIgnore]
        public string Response { get; set; }
    }
}