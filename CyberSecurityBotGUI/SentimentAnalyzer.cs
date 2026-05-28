using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBotGUI
{
    public class SentimentAnalyzer
    {
        public string DetectEmotion(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried"))
            {
                return "I understand your concern. Let me help you stay safe online.";
            }

            if (input.Contains("frustrated"))
            {
                return "Cybersecurity can feel overwhelming, but I can guide you.";
            }

            if (input.Contains("curious"))
            {
                return "That’s great! Learning about cybersecurity is very important.";
            }

            return "";
        }
    }
}