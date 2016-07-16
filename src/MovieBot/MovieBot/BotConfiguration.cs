using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MovieBot
{
    public static class BotConfiguration
    {
        public static bool FlushTelemetryClientAlways { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["FlushTelemetryClientAlways"]); } }
        public static string AppInsightInstrumentionKey { get { return ConfigurationManager.AppSettings["AppInsightInstrumentionKey"]; } }
    }
}