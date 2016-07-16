using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBot.Repository
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ViewIgnoreAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class ImageUriAttribute : Attribute
    {
    }
}