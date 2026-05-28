using System;
using System.Collections.Generic;

namespace CyberSecurityBotGUI
{
    public class ResponseManager
    {
        private Dictionary<string, List<string>> responses;
        private Random random;
        private string currentTopic = "";

        public ResponseManager()
        {
            random = new Random();

            responses = new Dictionary<string, List<string>>();

            responses.Add("password", new List<string>()
            {
                "Use strong passwords with symbols and numbers.",
                "Never reuse passwords across websites.",
                "Enable two-factor authentication for better security."
            });

            responses.Add("phishing", new List<string>()
            {
                "Never click suspicious links.",
                "Check email senders carefully.",
                "Scammers often pretend to be trusted companies."
            });

            responses.Add("privacy", new List<string>()
            {
                "Review your privacy settings regularly.",
                "Avoid sharing personal information online.",
                "Use secure websites when browsing."
            });
        }

        public string GetResponse(string input)
        {
            input = input.ToLower();

            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    currentTopic = keyword;

                    List<string> topicResponses = responses[keyword];

                    int index = random.Next(topicResponses.Count);

                    return topicResponses[index];
                }

                if (input.Contains("tell me more") || input.Contains("another tip"))
                {
                    if (responses.ContainsKey(currentTopic))
                    {
                        List<string> topicResponses =
                            responses[currentTopic];

                        int index =
                            random.Next(topicResponses.Count);

                        return topicResponses[index];
                    }
                }
            }

            return "I don't understand. Please try again.";
        }
    }
}
