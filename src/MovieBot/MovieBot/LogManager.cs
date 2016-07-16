using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace MovieBot
{
    public static class LogManager
    {
        private static TelemetryClient client;
        private static readonly bool flushAlways;
        private static readonly bool telemetryClientLogging;

        static LogManager()
        {

            //This calls Flush() after every message logged when true
            flushAlways = BotConfiguration.FlushTelemetryClientAlways;
            var instrumentationKey = BotConfiguration.AppInsightInstrumentionKey;
            TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;
            client = new TelemetryClient();
        }


        /// <summary>
        /// Converts the severity level so that it is compatible with Telemetry Client inputs
        /// </summary>
        /// <param name="severity">TraceEventType, input for the Enterprise Logging</param>
        /// <returns>SeverityLevel, input for TelemetryClient</returns>
        private static SeverityLevel GetSeverityLevel(TraceEventType severity)
        {
            switch (severity)
            {
                case TraceEventType.Error:
                    return SeverityLevel.Error;

                case TraceEventType.Warning:
                    return SeverityLevel.Warning;

                case TraceEventType.Verbose:
                    return SeverityLevel.Verbose;

                case TraceEventType.Critical:
                    return SeverityLevel.Critical;

                default:
                    return SeverityLevel.Information;
            }
        }

        /// <summary>
        /// Gets the default metric which triggers the alert in AppInsights (Telemetry Client)
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, double> GetAlertMetricDictionary()
        {
            return new Dictionary<string, double>
            {
                {"RaiseAlert", 5} //Value 5 has no special significance. Just some value greater than 1
            };
        }


        public static void LogCustomEvent(string message, IDictionary<string, string> customAttributes = null,
            IDictionary<string, double> metrics = null,
            TraceEventType severity = TraceEventType.Information,
            int eventid = 0, [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "")
        {
            if (customAttributes == null)
                customAttributes = new Dictionary<string, string>();
            if (metrics != null && metrics.Count == 0)
                metrics = null;

            client.TrackEvent(message, customAttributes, metrics);
            if (flushAlways)
                client.Flush();
        }

        public static void LogException(Exception exception, IDictionary<string, string> logAttributes = null,
            string information = null, IDictionary<string, double> metrics = null,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "")
        {
            if (logAttributes == null)
                logAttributes = new Dictionary<string, string>();

            if (metrics == null || metrics.Count == 0)
                metrics = GetAlertMetricDictionary();
            client.TrackException(exception, logAttributes, metrics);
            if (flushAlways)
                client.Flush();
        }


        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="customAttributes">Any Additional inputs that we want to add</param>
        /// <param name="severity"></param>
        /// <param name="eventid"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        public static void LogMessage(string message, IDictionary<string, string> customAttributes = null,
            TraceEventType severity = TraceEventType.Information,
            int eventid = 0, [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "")
        {
            if (customAttributes == null)
                customAttributes = new Dictionary<string, string>();

            bool status = false;

            client.TrackRequest("test", DateTime.Now, new TimeSpan(0, 10, 50), "200", status);

            client.TrackTrace(message, GetSeverityLevel(severity), customAttributes);
            if (flushAlways)
                client.Flush();
        }


        public static void LogMetric(string metricName, double metricValue)
        {

            client.TrackMetric(new MetricTelemetry(metricName, metricValue));
            if (flushAlways)
            {
                client.Flush();
            }
        }
    }
}