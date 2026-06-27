using System;
using System.Collections.Generic;

namespace CyberSecurityBotGUI
{
    public class ActivityLogger
    {

        private List<string> logs =
            new List<string>();



        public void Add(string activity)
        {

            string entry =
            DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            + " - "
            + activity;


            logs.Add(entry);

        }




        public string ShowLog()
        {

            if (logs.Count == 0)
            {
                return "No activity recorded yet.";
            }



            string result = "";


            foreach (string log in logs)
            {

                result += "• "
                + log
                + "\n";

            }


            return result;

        }



        public void ClearLog()
        {

            logs.Clear();

        }

    }
}