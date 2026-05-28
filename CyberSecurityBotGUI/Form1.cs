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
                "1️ Password Safety\n" +
                "2️ Phishing Attacks\n" +
                "3️ Online Privacy\n" +
                "4️ Tell Me More\n" +
                "5️ Another Tip\n" +
                "6️ I Am Worried\n" +
                "7️ I Am Frustrated\n" +
                "8️ My Name Is...\n" +
                "9️ What Do You Remember\n\n");

            rtbChat.AppendText(
                "💬 Example Questions:\n\n");

            rtbChat.AppendText(
                "• password\n" +
                "• phishing\n" +
                "• privacy\n" +
                "• tell me more\n" +
                "• another tip\n\n");

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
            string input = txtUserInput.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            // USER MESSAGE

            rtbChat.SelectionAlignment =
                HorizontalAlignment.Right;

            rtbChat.SelectionBackColor =
                Color.SkyBlue;

            rtbChat.SelectionColor =
                Color.Black;

            rtbChat.AppendText(
                "🧑 " + input + "\n\n");

            // SENTIMENT DETECTION

            string emotionResponse =
                sentiment.DetectEmotion(input);

            if (emotionResponse != "")
            {
                rtbChat.SelectionAlignment =
                    HorizontalAlignment.Left;

                rtbChat.SelectionBackColor =
                    Color.Gainsboro;

                rtbChat.SelectionColor =
                    Color.Black;

                rtbChat.AppendText(
                    "🤖 " + emotionResponse + "\n\n");

                txtUserInput.Clear();
                return;
            }

            // MEMORY

            if (input.ToLower().Contains("my name is"))
            {
                memory.UserName =
                    input.Replace("my name is", "").Trim();

                rtbChat.SelectionAlignment =
                    HorizontalAlignment.Left;

                rtbChat.SelectionBackColor =
                    Color.Gainsboro;

                rtbChat.SelectionColor =
                    Color.Black;

                rtbChat.AppendText(
                    "🤖 Nice to meet you " +
                    memory.UserName + "!\n\n");

                txtUserInput.Clear();
                return;
            }

            if (input.ToLower().Contains("i like"))
            {
                memory.FavouriteTopic =
                    input.Replace("i like", "").Trim();

                rtbChat.SelectionAlignment =
                    HorizontalAlignment.Left;

                rtbChat.SelectionBackColor =
                    Color.Gainsboro;

                rtbChat.SelectionColor =
                    Color.Black;

                rtbChat.AppendText(
                    "🤖 I will remember that you like " +
                    memory.FavouriteTopic + ".\n\n");

                txtUserInput.Clear();
                return;
            }

            // RECALL

            if (input.ToLower().Contains(
                "what do you remember"))
            {
                rtbChat.SelectionAlignment =
                    HorizontalAlignment.Left;

                rtbChat.SelectionBackColor =
                    Color.Gainsboro;

                rtbChat.SelectionColor =
                    Color.Black;

                rtbChat.AppendText(
                    "🤖 Your name is " +
                    memory.UserName +
                    " and you like " +
                    memory.FavouriteTopic +
                    ".\n\n");

                txtUserInput.Clear();
                return;
            }

            // CHATBOT RESPONSE

            string response =
                manager.GetResponse(input);

            rtbChat.SelectionAlignment =
                HorizontalAlignment.Left;

            rtbChat.SelectionBackColor =
                Color.Gainsboro;

            rtbChat.SelectionColor =
                Color.Black;

            rtbChat.AppendText(
                "🤖 " + response + "\n\n");

            txtUserInput.Clear();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}