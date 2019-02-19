using System;
using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class SurveyCampaignMaker : ISurveyCampaignMaker
    {
        private readonly IQuestionHelper _questionHelper;
        private readonly ISurveyLocationGetter _surveyLocationGetter;
        private readonly ISurveyQuestionGetter _surveyQuestionGetter;

        public SurveyCampaignMaker(IQuestionHelper questionHelper, 
            ISurveyLocationGetter surveyLocationGetter,
            ISurveyQuestionGetter surveyQuestionGetter)
        {
            _questionHelper = questionHelper;
            _surveyLocationGetter = surveyLocationGetter;
            _surveyQuestionGetter = surveyQuestionGetter;
        }

        public Campaign CreateNewCampaign()
        {
            Console.WriteLine("Welcome in the survey campaign maker.");

            var answer = _questionHelper.AskYesNoQuestion("Would you like to create a new survey campaign ?");
            if (answer)
            {
                Console.WriteLine("Ok, let's make a survey.");

                var survey = _surveyQuestionGetter.GetSurveyQuestion();
                var locationList = _surveyLocationGetter.GetSurveyLocation();

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
