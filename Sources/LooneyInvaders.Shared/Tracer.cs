using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;

namespace LooneyInvaders
{
    public static class Tracer
    {
        private static string title;
        public static string Title
        {
            get => title;
            set => title = value ?? string.Empty;
        }

        private static string id;
        public static (string Id, Dictionary<string, string> Messages) Tracker
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                {
                    id = Guid.NewGuid().ToString().Substring(0, 4);
                    messages = new Dictionary<string, string>();
                }

                return (id, messages);
            }
        }
        private static Dictionary<string, string> messages;


        public static void Trace(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif
        }

        public static void Track(string message, IDictionary<string, string> properties = null)
        {
            Analytics.TrackEvent(message, properties);
        }

        public static void TrackerAppendUntil(string description, bool condition = false, bool resetTracker = false)
        {
            if (description == null)
            {
                return;
            }
            Tracker.Messages.TryAdd($"[{description}]", $"[{Tracker.Id}][{Title}]");

            if (resetTracker)
            {
                if (condition)
                {
                    Track($"{Tracker.Id}-Event", Tracker.Messages);
                }
                id = null;
            }
        }
    }
}
