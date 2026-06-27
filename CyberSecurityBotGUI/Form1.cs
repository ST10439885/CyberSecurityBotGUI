using System;
using System.Drawing;
using System.Windows.Forms;

namespace CyberSecurityBotGUI
{
    public partial class Form1 : Form
    {

        ResponseManager manager =
            new ResponseManager();

        SentimentAnalyzer sentiment =
            new SentimentAnalyzer();

        MemoryManager memory =
            new MemoryManager();

        AudioManager audio =
            new AudioManager();

        TaskManager taskManager =
            new TaskManager();

        QuizManager quiz =
            new QuizManager();

        ActivityLogger logger =
            new ActivityLogger();



        public Form1()
        {
            InitializeComponent();

            audio.PlayGreeting();


            rtbChat.SelectionAlignment =
                HorizontalAlignment.Left;

            rtbChat.SelectionBackColor =
                Color.Gainsboro;

            rtbChat.SelectionColor =
                Color.Black;



            rtbChat.AppendText(
                "🤖 Welcome to Sentinel Shield!\n\n");


            rtbChat.AppendText(
                "🔒 CYBERSECURITY MENU 🔒\n\n");


            rtbChat.AppendText(
                "1 Password Safety\n" +
                "2 Phishing Attacks\n" +
                "3 Online Privacy\n" +
                "4 Tell Me More\n" +
                "5 Another Tip\n" +
                "6 I Am Worried\n" +
                "7 I Am Frustrated\n" +
                "8 My Name Is...\n" +
                "9 What Do You Remember\n\n");


            rtbChat.AppendText(
                "💬 Examples:\n\n" +
                "• password\n" +
                "• phishing\n" +
                "• privacy\n" +
                "• add task\n" +
                "• start quiz\n\n");


            rtbChat.AppendText(
                "😊 Start chatting below...\n\n");

        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {

                btnSend.PerformClick();

                e.SuppressKeyPress = true;

            }

        }





        private void btnSend_Click(object sender, EventArgs e)
        {

            string input =
                txtUserInput.Text;


            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }


            rtbChat.SelectionAlignment =
                HorizontalAlignment.Right;

            rtbChat.SelectionBackColor =
                Color.SkyBlue;

            rtbChat.SelectionColor =
                Color.Black;


            rtbChat.AppendText(
                "🧑 " + input + "\n\n");


            if (input.ToLower()
                .Contains("show activity log"))
            {


                rtbChat.AppendText(
                "🤖 Activity Log:\n\n" +
                logger.ShowLog()
                + "\n\n");


                txtUserInput.Clear();

                return;

            }


            if (input.ToLower()
                .Contains("start quiz"))
            {


                rtbChat.AppendText(
                "🤖 Quiz Started!\n\n" +
                quiz.NextQuestion()
                + "\n\n");


                logger.Add(
                "User started quiz");


                txtUserInput.Clear();

                return;

            }

            if (input.ToLower().StartsWith("answer"))
            {

                string answer =
                input.Replace("answer", "")
                .Trim();


                rtbChat.AppendText(
                "🤖 " +
                quiz.CheckAnswer(answer)
                + "\n\n");


                rtbChat.AppendText(
                "🤖 " +
                quiz.NextQuestion()
                + "\n\n");


                txtUserInput.Clear();

                return;

            }


            if (input.ToLower()
                .Contains("add task"))
            {


                taskManager.AddTask(input);


                rtbChat.AppendText(
                "🤖 Task added successfully!\n\n");


                logger.Add(
                "Task added: " + input);



                txtUserInput.Clear();

                return;

            }


            if (input.ToLower()
                .Contains("show tasks"))
            {


                rtbChat.AppendText(
                "🤖 Your Tasks:\n\n" +
                taskManager.ViewTasks()
                + "\n\n");


                logger.Add(
                "User viewed tasks");


                txtUserInput.Clear();

                return;

            }



            string emotionResponse =
                sentiment.DetectEmotion(input);



            if (emotionResponse != "")
            {


                rtbChat.AppendText(
                "🤖 " +
                emotionResponse +
                "\n\n");


                logger.Add(
                "Sentiment detected");


                txtUserInput.Clear();

                return;

            }



            if (input.ToLower()
                .Contains("my name is"))
            {


                memory.UserName =
                input.Replace(
                "my name is", "")
                .Trim();



                rtbChat.AppendText(
                "🤖 Nice to meet you "
                + memory.UserName
                + "!\n\n");



                logger.Add(
                "Saved user name");



                txtUserInput.Clear();

                return;

            }



            if (input.ToLower()
                .Contains("i like"))
            {


                memory.FavouriteTopic =
                input.Replace(
                "i like", "")
                .Trim();



                rtbChat.AppendText(
                "🤖 I will remember that you like "
                + memory.FavouriteTopic
                + ".\n\n");



                logger.Add(
                "Saved favourite topic");



                txtUserInput.Clear();

                return;

            }



            if (input.ToLower()
                .Contains("what do you remember"))
            {


                rtbChat.AppendText(
                "🤖 Your name is "
                + memory.UserName
                + " and you like "
                + memory.FavouriteTopic
                + ".\n\n");



                txtUserInput.Clear();

                return;

            }




            string response =
                manager.GetResponse(input);



            rtbChat.SelectionAlignment =
                HorizontalAlignment.Left;


            rtbChat.SelectionBackColor =
                Color.Gainsboro;


            rtbChat.SelectionColor =
                Color.Black;



            rtbChat.AppendText(
            "🤖 " +
            response +
            "\n\n");
             


            logger.Add(
            "User asked: " + input);



            txtUserInput.Clear();


        }




        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            rtbChat.AppendText(
            "🤖 " + quiz.NextQuestion()
            + "\n\n");
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            rtbChat.AppendText(
            "🤖 Tasks:\n\n" +
            taskManager.ViewTasks()
          + "\n\n");
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            rtbChat.AppendText(
            "🤖 Activity:\n\n" +
            logger.ShowLog()
            + "\n\n");
        }
    }
}