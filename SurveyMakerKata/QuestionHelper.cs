using System;
using System.Collections.Generic;

namespace SurveyMakerKata
{
    public static class QuestionHelper
    {
        public static string AskQuestion(string question)
        {
            string answer = string.Empty;
            while (answer.Length == 0)
            {
                Console.WriteLine("Open question : " + question);
                answer = Console.ReadLine();
            }

            return answer;
        }

        public static bool AskYesNoQuestion(string question)
        {
            string answer = null;
            bool yes;
            bool no;
            while (true)
            {
                Console.WriteLine("Yes/No question : " + question);
                answer = Console.ReadLine();

                if (answer.Length != 0)
                {
                    if (yes = IsYesNoQuestionAnswerByYes(answer))
                    {
                        return true;
                    }
                    else if (no = IsYesNoQuestionAnswerByNo(answer))
                    {
                        return false;
                    }
                }

                Console.WriteLine("Please answer by 'yes' or 'no'");
            }
        }

        public static string AskOptionalQuestion(string question)
        {
            string answer = null;

            Console.WriteLine("Optional question : " + question);
            answer = Console.ReadLine();

            return answer.Length == 0 ? string.Empty : answer;
        }

        private static bool IsYesNoQuestionAnswerByYes(string answer)
        {
            var yesList = new List<string> { "y", "yes", "Y", "Yes", "o", "oui", "O", "Oui" };

            return yesList.Contains(answer);
        }

        private static bool IsYesNoQuestionAnswerByNo(string answer)
        {
            var noList = new List<string> { "n", "no", "N", "No", "non", "Non" };

            return noList.Contains(answer);
        }
    }
}
