using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyMakerKata
{
    public class SurveyCampaignMaker
    {
        public Campaign CreateNewCampaign()
        {
            Console.WriteLine("Welcome in the survey campaign maker.");

            var answer = AskYesNoQuestion("Would you like to create a new survey campaign ?");
            if (answer)
            {
                Console.WriteLine("Ok, let's make a survey.");
                var surveySummary = AskOptionalQuestion("What is your survey summary ?");
                var surveyClientName = AskQuestion("What is your client name ?");
                var surveyClientAdress = AskQuestion("What is your client adress ?");

                var questionList = new List<ISurveyQuestion>();
                do
                {
                    var question = AskQuestion("What question do you want to ask ?");
                    var surveyQuestion = new SurveyQuestion();

                    surveyQuestion.Question = question;
                    surveyQuestion.Id = questionList.Count + 1;

                    questionList.Add(surveyQuestion);
                } while (AskYesNoQuestion("Do you want to add another question ?"));

                var survey = new Survey(1, surveySummary, surveyClientName, surveyClientAdress, questionList);

                //// Debug
                //Console.WriteLine("So far, we have a survey with the following attributes :" + Environment.NewLine +
                //    $"The client's name is {survey.ClientName}." + Environment.NewLine +
                //    $"The client's adress is {survey.ClientAdress}" + Environment.NewLine +
                //    $"The survey has {survey.QuestionList.Count} question." +Environment.NewLine +
                //    $"The first question being : {survey.QuestionList.First().Question}");

                var locationList = new List<ISurveyLocations>();
                do
                {
                    var numVoieStr = AskQuestion("Where would you like to ask questions ? Give street number :");

                    int numVoie = 1;
                    int.TryParse(numVoieStr, out numVoie);

                    var nomVoie = AskQuestion("Where would you like to ask questions ? Give street name :");
                    var zipCode = AskQuestion("Where would you like to ask questions ? Give zip code :");
                    var city = AskQuestion("Where would you like to ask questions ? Give city name :");
                    var surveyAdress = new SurveyAdress(locationList.Count + 1, numVoie, nomVoie, zipCode, city);
                    var surveyLocation = new SurveyLocations(1, surveyAdress, CompletionStatus.TODO);

                    locationList.Add(surveyLocation);
                } while (AskYesNoQuestion("Do you want to add another survey location ?"));

                Console.WriteLine("Survey created !");

                return new Campaign(survey, locationList);
            }

            Console.WriteLine("See you later !");
            Console.ReadKey();
            return null;
        }

        private string AskQuestion(string question)
        {
            string answer = string.Empty;
            while (answer.Length == 0)
            {
                Console.WriteLine("Open question : " + question);
                answer = Console.ReadLine();
            }

            return answer;
        }

        private bool AskYesNoQuestion(string question)
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

        private string AskOptionalQuestion(string question)
        {
            string answer = null;

            Console.WriteLine("Optional question : " + question);
            answer = Console.ReadLine();

            return answer.Length == 0 ? string.Empty : answer;
        }

        private bool IsYesNoQuestionAnswerByYes(string answer)
        {
            var yesList = new List<string> { "y", "yes", "Y", "Yes", "o", "oui", "O", "Oui" };

            return yesList.Contains(answer);
        }

        private bool IsYesNoQuestionAnswerByNo(string answer)
        {
            var noList = new List<string> { "n", "no", "N", "No", "non", "Non"};

            return noList.Contains(answer);
        }
    }
}
