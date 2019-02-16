using System;
using System.Collections.Generic;

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
                var surveyClientAdress = QuestionHelper.AskQuestion("What is your client adress ?");

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
                //Console.WriteLine("So far, we have a survey with the following attributes :" + Environment.NewLine +
                //    $"The client's name is {survey.ClientName}." + Environment.NewLine +
                //    $"The client's adress is {survey.ClientAdress}" + Environment.NewLine +
                //    $"The survey has {survey.QuestionList.Count} question." +Environment.NewLine +
                //    $"The first question being : {survey.QuestionList.First().Question}");

                var locationList = new List<ISurveyLocations>();
                do
                {
                    var numVoieStr = QuestionHelper.AskQuestion("Where would you like to ask questions ? Give street number :");

                    int.TryParse(numVoieStr, out int numVoie);

                    var nomVoie = QuestionHelper.AskQuestion("Where would you like to ask questions ? Give street name :");
                    var zipCode = QuestionHelper.AskQuestion("Where would you like to ask questions ? Give zip code :");
                    var city = QuestionHelper.AskQuestion("Where would you like to ask questions ? Give city name :");
                    var surveyAdress = new SurveyAdress(locationList.Count + 1, numVoie, nomVoie, zipCode, city);
                    var surveyLocation = new SurveyLocations(locationList.Count + 100, surveyAdress, CompletionStatus.TODO);

                    locationList.Add(surveyLocation);
                } while (locationList.Count < 4 && QuestionHelper.AskYesNoQuestion("Do you want to add another survey location ?"));

                //// Debug
                //Console.WriteLine("So far, we have a location list with the following attributes :" + Environment.NewLine +
                //    $"There is {locationList.Count} survey locations." + Environment.NewLine +
                //    $"The first location being {locationList.First().Adress.NumVoie} " +
                //    $"{locationList.First().Adress.NomVoie} " +
                //    $"in {locationList.First().Adress.CityName}, {locationList.First().Adress.ZipCode} ");

                Console.WriteLine("Survey campaign created !");

                return new Campaign(survey, locationList)
                {
                    Id = 175
                };
            }
            else
            {
                Console.WriteLine("We'll use a pre-made survey then!");

                return new Campaign(new Survey(100, "I wonder who like cakes", "KONG To", "7 rue du Louvre", new List<ISurveyQuestion>
                {
                    new SurveyQuestion { Id = 1, Question = "Do you like chocolate cakes ?"}, 
                    new SurveyQuestion { Id = 2, Question = "Do you like carrot cakes ?"},
                    new SurveyQuestion { Id = 3, Question = "Do you like all cakes ?"}
                }),
                new List<ISurveyLocations> {
                    new SurveyLocations(456, new SurveyAdress(7, 7, "rue de Rivoli", "75005", "Paris"), CompletionStatus.In_Progress),
                    new SurveyLocations(456, new SurveyAdress(8, 115, "rue de Tolbiac", "75013", "Paris"), CompletionStatus.In_Progress),
                });
            }
        }
    }
}
