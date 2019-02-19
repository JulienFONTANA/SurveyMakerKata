using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class SurveyQuestionGetter : ISurveyQuestionGetter
    {
        private readonly IQuestionHelper _questionHelper;
        private readonly ISurveyAdressGetter _surveyAdressGetter;

        public SurveyQuestionGetter(IQuestionHelper questionHelper,
            ISurveyAdressGetter surveyAdressGetter)
        {
            _questionHelper = questionHelper;
            _surveyAdressGetter = surveyAdressGetter;
        }

        public Survey GetSurveyQuestion()
        {
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
            return survey;
        }
    }
}
