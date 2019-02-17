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

            var answer = QuestionHelper.AskYesNoQuestion("Would you like to create a new survey campaign ?");
            if (answer)
            {
                Console.WriteLine("Ok, let's make a survey.");
                var surveySummary = QuestionHelper.AskOptionalQuestion("What is your survey summary ?");
                var surveyClientName = QuestionHelper.AskQuestion("What is your client name ?");
                var surveyClientAdress = GetSurveyAdress(123, isClientAdress: true);

                var questionList = new List<ISurveyQuestion>();
                do
                {
                    var question = QuestionHelper.AskQuestion("What question do you want to ask ?");
                    var surveyQuestion = new SurveyQuestion
                    {
                        Question = question,
                        Id = questionList.Count + 1
                    };

                    questionList.Add(surveyQuestion);
                } while (questionList.Count < 10 && QuestionHelper.AskYesNoQuestion("Do you want to add another question ?"));

                var survey = new Survey(100, surveySummary, surveyClientName, surveyClientAdress, questionList);

                //// Debug
                //PrintSurveyInfo(survey);

                var locationList = new List<ISurveyLocations>();
                do
                {
                    var surveyLocation = new SurveyLocations(locationList.Count + 100, GetSurveyAdress(locationList.Count + 45), CompletionStatus.TODO);
                    locationList.Add(surveyLocation);
                } while (locationList.Count < 4 && QuestionHelper.AskYesNoQuestion("Do you want to add another survey location ?"));

                //// Debug
                //PrintLocationInfo(locationList);

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

            var numVoieStr = QuestionHelper.AskQuestion(firstQuestion + "Give street number :");
            int.TryParse(numVoieStr, out int numVoie);

            var nomVoie = QuestionHelper.AskQuestion("Where would you like to ask questions ? Give street name :");
            var zipCode = QuestionHelper.AskQuestion("Where would you like to ask questions ? Give zip code :");
            var city = QuestionHelper.AskQuestion("Where would you like to ask questions ? Give city name :");

            return new SurveyAdress(id, numVoie, nomVoie, zipCode, city);
        }

        #region DebugFct
        private void PrintSurveyInfo(Survey survey)
        {
            Console.WriteLine("So far, we have a survey with the following attributes :" + Environment.NewLine +
                $"The client's name is {survey.ClientName}." + Environment.NewLine +
                $"The client's adress is {survey.ClientAdress}" + Environment.NewLine +
                $"The survey has {survey.QuestionList.Count} question." + Environment.NewLine +
                $"The first question being : {survey.QuestionList.First().Question}");
        }

        private void PrintLocationInfo(List<ISurveyLocations> locationList)
        {
            Console.WriteLine("So far, we have a location list with the following attributes :" + Environment.NewLine +
                $"There is {locationList.Count} survey locations." + Environment.NewLine +
                $"The first location being {locationList.First().Adress.NumVoie} " +
                $"{locationList.First().Adress.NomVoie} " +
                $"in {locationList.First().Adress.CityName}, {locationList.First().Adress.ZipCode} ");
        }
        #endregion
    }
}
