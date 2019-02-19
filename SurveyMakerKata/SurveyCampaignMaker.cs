using System;
using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class SurveyCampaignMaker : ISurveyCampaignMaker
    {
        private readonly IQuestionHelper _questionHelper;
        private readonly ISurveyAdressGetter _surveyAdressGetter;

        public SurveyCampaignMaker(IQuestionHelper questionHelper, 
            ISurveyAdressGetter surveyAdressGetter)
        {
            _questionHelper = questionHelper;
            _surveyAdressGetter = surveyAdressGetter;
        }

        public Campaign CreateNewCampaign()
        {
            Console.WriteLine("Welcome in the survey campaign maker.");

            var answer = _questionHelper.AskYesNoQuestion("Would you like to create a new survey campaign ?");
            if (answer)
            {
                Console.WriteLine("Ok, let's make a survey.");
                var surveySummary = _questionHelper.AskOptionalQuestion("What is your survey summary ?");
                var surveyClientName = _questionHelper.AskQuestion("What is your client name ?");
                var surveyClientAdress = _surveyAdressGetter.GetSurveyAdress(123, isClientAdress: true);

                var questionList = new List<ISurveyQuestion>();
                do
                {
                    var question = _questionHelper.AskQuestion("What question do you want to ask ?");
                    var surveyQuestion = new SurveyQuestion
                    {
                        Question = question,
                        Id = questionList.Count + 1
                    };

                    questionList.Add(surveyQuestion);
                } while (questionList.Count < 10 && _questionHelper.AskYesNoQuestion("Do you want to add another question ?"));

                var survey = new Survey(100, surveySummary, surveyClientName, surveyClientAdress, questionList);

                var locationList = new List<ISurveyLocations>();
                do
                {
                    var surveyLocation = new SurveyLocations(locationList.Count + 100, _surveyAdressGetter.GetSurveyAdress(locationList.Count + 45), CompletionStatus.TODO);
                    locationList.Add(surveyLocation);
                } while (locationList.Count < 4 && _questionHelper.AskYesNoQuestion("Do you want to add another survey location ?"));

                Console.WriteLine("Survey campaign created !");

                return new Campaign(survey, locationList)
                {
                    Id = 175,
                    SurveyId = survey.Id
                };
            }
            else
            {
                return GetPreMadeCampaign();
            }
        }

        private Campaign GetPreMadeCampaign()
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
                        new SurveyLocations(457, new SurveyAdress(8, 115, "rue de Tolbiac", "75013", "Paris"), CompletionStatus.In_Progress),
                })
            {
                SurveyId = 100
            };
        }
    }
}
