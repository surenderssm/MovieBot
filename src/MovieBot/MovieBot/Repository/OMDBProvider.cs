using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;

namespace MovieBot.Repository
{
    public class OMDBProvider
    {
        string uri = "http://www.omdbapi.com/";
        public OMDBProvider()
        {

        }
        public async Task<OMDBMovie> Get(string title)
        {
            OMDBMovie movie = null;
            string rawContent;
            string uri = $"http://www.omdbapi.com/?t={title}&y=&plot=short&r=json";
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await client.SendAsync(request);
                rawContent = await response.Content.ReadAsStringAsync();
            }
            try
            {
                movie = JsonConvert.DeserializeObject<OMDBMovie>(rawContent);
            }
            catch (Exception ex)
            {
                // TODO:
            }

            if (movie?.Response?.ToLower().Equals("true") == true)
            {
                return movie;
            }
            else
            {
                return null;
            }
        }

        public async Task<OMDBMovieSearch> Search(string title)
        {
            // TODO : can be optimized and single function for make request
            OMDBMovieSearch movieSearch = null;
            string rawContent;
            string uri = $"http://www.omdbapi.com/?s={title}&y=&plot=short&r=json";
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await client.SendAsync(request);
                rawContent = await response.Content.ReadAsStringAsync();
            }
            try
            {
                movieSearch = JsonConvert.DeserializeObject<OMDBMovieSearch>(rawContent);
            }
            catch (Exception ex)
            {
                // TODO:
            }

            if (movieSearch?.Response?.ToLower().Equals("true") == true)
            {
                return movieSearch;
            }
            else
            {
                return null;
            }
        }
    }
}