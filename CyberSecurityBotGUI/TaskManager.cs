using System.Collections.Generic;

namespace CyberSecurityBotGUI
{
    public class TaskManager
    {

        private List<string> tasks =
            new List<string>();


        public void AddTask(string task)
        {

            tasks.Add(task);

        }



        public string ViewTasks()
        {

            if (tasks.Count == 0)
            {
                return "No tasks found.";
            }


            string result = "";


            foreach (string task in tasks)
            {

                result += "• " + task + "\n";

            }


            return result;

        }



        public void RemoveTask(string task)
        {

            tasks.Remove(task);

        }

    }
}