using System;
using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class SurveyCampaignMaker : ISurveyCampaignMaker
    {
        private readonly IQuestionHelper questionHelper = new QuestionHelper();

        public Campaign CreateNewCampaign()
        {
            Console.WriteLine("Welcome in the survey campaign maker.");

            var answer = questionHelper.AskYesNoQuestion("Would you like to create a new survey campaign ?");
            if (answer)
            {
                Console.WriteLine("Ok, let's make a survey.");
                var surveySummary = questionHelper.AskOptionalQuestion("What is your survey summary ?");
                var surveyClientName = questionHelper.AskQuestion("What is your client name ?");
                var surveyClientAdress = GetSurveyAdress(123, isClientAdress: true);

                var questionList = new List<ISurveyQuestion>();
                do
                {
                    var question = questionHelper.AskQuestion("What question do you want to ask ?");
                    var surveyQuestion = new SurveyQuestion
                    {
                        Question = question,
                        Id = questionList.Count + 1
                    };

                    questionList.Add(surveyQuestion);
                } while (questionList.Count < 10 && questionHelper.AskYesNoQuestion("Do you want to add another question ?"));

                var survey = new Survey(100, surveySummary, surveyClientName, surveyClientAdress, questionList);

                var locationList = new List<ISurveyLocations>();
                do
                {
                    var surveyLocation = new SurveyLocations(locationList.Count + 100, GetSurveyAdress(locationList.Count + 45), CompletionStatus.TODO);
                    locationList.Add(surveyLocation);
                } while (locationList.Count < 4 && questionHelper.AskYesNoQuestion("Do you want to add another survey location ?"));

                Console.WriteLine("Survey campaign created !");

                return new Campaign(survey, locationList)
                {
                    Id = 175,
                    SurveyId = survey.Id
                };
            }
            else
            {
                Console.WriteLine("We'll use a pre-made survey then!");

                return new Campaign(new Survey(100, "I wonder who like cakes", "KONG To",
                    new SurveyAdress(8, 7, "rue de Rivoli", "75003", "PARIS"),
                    new List<ISurveyQuestion>
                    {
                        new SurveyQuestion { Id = 1, Question = "Do you like chocolate cakes ?"},
                        new SurveyQuestion { Id = 2, Question = "Do you like carrot cakes ?"},
                        new SurveyQuestion { Id = 3, Question = "Do you like all cakes ?"}
                    }),
                    new List<ISurveyLocations> {
                        new SurveyLocations(456, new SurveyAdress(7, 7, "rue de Rivoli", "75005", "Paris"), CompletionStatus.In_Progress),
                        new SurveyLocations(456, new SurveyAdress(8, 115, "rue de Tolbiac", "75013", "Paris"), CompletionStatus.In_Progress),
                    })
                {
                    SurveyId = 100
                };
            }
        }

        private SurveyAdress GetSurveyAdress(int id, bool isClientAdress = false)
        {
            var firstQuestion = isClientAdress ? "Where does the client lives ? " : "Where would you like to ask questions ? ";

            var numVoieStr = questionHelper.AskQuestion(firstQuestion + "Give street number :");
            int.TryParse(numVoieStr, out int numVoie);

            var nomVoie = questionHelper.AskQuestion("Where would you like to ask questions ? Give street name :");
            var zipCode = questionHelper.AskQuestion("Where would you like to ask questions ? Give zip code :");
            var city = questionHelper.AskQuestion("Where would you like to ask questions ? Give city name :");

            return new SurveyAdress(id, numVoie, nomVoie, zipCode, city);
        }
    }
}
