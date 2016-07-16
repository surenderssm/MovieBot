using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace MovieBot
{
    [BotAuthentication]
    public class MovieMessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {

            try
            {
                LogMessage(message);
                if (message.Type == "Message")
                {
                    string showData = string.Empty;
                    string titleText = message.Text;
                    titleText = titleText.Trim().ToLower();

                    if (titleText.Equals("hi") || titleText.Equals("hi!") || titleText.Equals("hi !"))
                    {
                        showData = PublicMessages.IntroductoryMessage;
                    }
                    else if (titleText.Equals("help"))
                    {
                        showData = PublicMessages.HelpMessage;
                    }
                    else if (titleText.Contains("*"))
                    {
                        titleText = titleText.Replace("*", "");
                        titleText = titleText.Trim();
                        showData = await SearchMovie(titleText);
                    }
                    else
                    {
                        var movie = await Repository.MovieRepository.Get(message.Text);
                        if (movie != null)
                        {
                            showData = Utility.GetViewableObject(movie);
                        }
                        else
                        {
                            showData = await SearchMovie(titleText);
                        }
                    }
                    return message.CreateReplyMessage(showData);
                }
                else
                {
                    return HandleSystemMessage(message);

                }
            }
            catch (Exception ex)
            {
                Dictionary<string, string> items = new Dictionary<string, string>();
                items.Add("MessageText", message.Text);
                LogManager.LogException(ex, items);
                return message.CreateReplyMessage(PublicMessages.NoInformationMessage);
            }
        }
        private async Task<string> SearchMovie(string title)
        {
            string response = string.Empty;
            var movieSearch = await Repository.MovieRepository.Search(title);

            if (movieSearch?.Search?.Count() > 0)
            {
                for (int index = 0; index < movieSearch.Search.Count(); index++)
                {
                    response += Utility.NewLine + $"{movieSearch.Search[index].Title}";
                }

                response += Utility.NewLine + $"***Do you mean any of the above {movieSearch.Search.Count()}, If yes please type the title again.***";
            }
            else
            {
                response = "I am really sorry,I don't know the details of the movie you are looking for :( . Please give me a chance by trying again.";
                response = PublicMessages.NoInformationMessage;
            }
            return response;
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping from sumali";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
                return message.CreateReplyMessage(PublicMessages.IntroductoryMessage);

            }
            else if (message.Type == "BotRemovedFromConversation")
            {
                return message.CreateReplyMessage("Thank you");

            }
            else if (message.Type == "UserAddedToConversation")
            {
                return message.CreateReplyMessage(PublicMessages.IntroductoryMessage);
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
                return message.CreateReplyMessage("Thank you");

            }
            else if (message.Type == "EndOfConversation")
            {
                return message.CreateReplyMessage("Thank you");
            }

            return null;
        }

        private void LogMessage(Message msg)
        {
            Dictionary<string, string> items = new Dictionary<string, string>();
            items.Add("MessageText", msg.Text);
            var rawMessage = JsonConvert.SerializeObject(msg);
            LogManager.LogMessage(rawMessage, items);
        }
    }
}