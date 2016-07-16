using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBot
{
    public static class Utility
    {
        public const string NewLine = "  \n";
        public static string GetViewableObject(object currentObject)
        {
            string newLine = "  \n";
            string result = string.Empty;
            if (currentObject != null)
            {
                foreach (var prop in currentObject.GetType().GetProperties())
                {
                    // TODO: more generic
                    var attribute = prop.GetCustomAttributes(true).ToList().FirstOrDefault();
                    string propValue = prop.GetValue(currentObject).ToString();
                    string propName = prop.Name;


                    if (attribute == null)
                    {
                        result += newLine + $"**{prop.Name}** : {prop.GetValue(currentObject)}";
                    }
                    else if (attribute as Repository.ImageUriAttribute != null)
                    {
                        propValue = $"![Poster]({propValue})";
                        result += newLine + propValue;
                    }

                    // TODO : case for ViewIgnore if required ?
                }
            }
            return result;
        }
    }
}