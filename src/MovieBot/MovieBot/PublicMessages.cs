using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBot
{
    //http://docs.botframework.com/connector/message-content/

    public static class PublicMessages
    {
        public const string IntroductoryMessage = @"Hi I'm Movie Bot.Click [here](https://dev.botframework.com/bots?id=sumalimoviebot) to find out more about me and my policies."
            + Utility.NewLine + "Please type title/word\\* of Movie or TV Series you interested in for details.For Eg Titanic or Game\\*.";

        public const string HelpMessage = @"Hello.What are you up to?"
        + Utility.NewLine + @"I'm only capable of following now.I'm still learning. Thanks for your understanding."
+ Utility.NewLine + Utility.NewLine + "Please type title/word\\* of Movie or TV Series you interested in, I'll give you the details like Rating, Votes, Awards, Plot, Genre, and more details."
+ Utility.NewLine + "If you are not sure of the exact tile, try by typing any word of the same (eg : Game\\* for something like 'Game of Thrones'), it will give you the list of titles which might contain your title.";

        public const string NoInformationMessage = "I am really sorry :( ! I'll have to think about that one." + Utility.NewLine + "Type **help** to see what I can do."
            + Utility.NewLine + "Give us [feedback](mailto:surender19@hotmail.com?subject=[Feedback]%20To%20MovieBot) to help us improve.";
    }
}