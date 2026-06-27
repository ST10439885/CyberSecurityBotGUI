using System.Collections.Generic;

namespace CyberSecurityBotGUI
{
    public class QuizManager
    {

        private int currentQuestion = 0;

        private int score = 0;


        private List<string> questions =
        new List<string>()
        {

            "1. What is phishing?\nA) A game\nB) A fake message used to steal information\nC) A computer update",

            "2. Should you share your password with others?\nA) Yes\nB) No",

            "3. What does 2FA mean?\nA) Two Factor Authentication\nB) Two File Access\nC) Fast Access",

            "4. What is malware?\nA) Malicious software\nB) A password\nC) A website",

            "5. Why should you update software?\nA) For security fixes\nB) To slow your computer\nC) To remove passwords",

            "6. What makes a strong password?\nA) Your name\nB) A mix of letters, numbers and symbols\nC) 12345",

            "7. What is ransomware?\nA) A security tool\nB) A virus that locks files\nC) A browser",

            "8. What does encryption do?\nA) Protects information by converting it into a secure format\nB) Deletes files\nC) Creates viruses",

            "9. Why should you avoid suspicious links?\nA) They may contain scams\nB) They improve security\nC) They are always safe",

            "10. What is online privacy?\nA) Protecting your personal information online\nB) Sharing everything online\nC) Removing passwords"

        };



        private List<string> answers =
        new List<string>()
        {

            "B",
            "B",
            "A",
            "A",
            "A",
            "B",
            "B",
            "A",
            "A",
            "A"

        };




        public string NextQuestion()
        {

            if (currentQuestion < questions.Count)
            {

                string question =
                questions[currentQuestion];


                currentQuestion++;


                return question;

            }


            return
            "Quiz finished! Your score: "
            + score +
            "/" +
            questions.Count;

        }





        public string CheckAnswer(string answer)
        {

            int index =
            currentQuestion - 1;


            if (answer.ToUpper()
                == answers[index])
            {

                score++;

                return "✅ Correct!";

            }


            return "❌ Incorrect.";

        }




        public void ResetQuiz()
        {

            currentQuestion = 0;

            score = 0;

        }


    }
}