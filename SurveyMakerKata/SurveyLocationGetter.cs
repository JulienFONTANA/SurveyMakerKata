using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class SurveyLocationGetter : ISurveyLocationGetter
    {
        private readonly IQuestionHelper _questionHelper;
        private readonly ISurveyAdressGetter _surveyAdressGetter;

        public SurveyLocationGetter(IQuestionHelper questionHelper,
            ISurveyAdressGetter surveyAdressGetter)
        {
            _questionHelper = questionHelper;
            _surveyAdressGetter = surveyAdressGetter;
        }

        public List<ISurveyLocations> GetSurveyLocation()
        {
            var locationList = new List<ISurveyLocations>();
            do
            {
                var surveyLocation = new SurveyLocations(locationList.Count + 100,
                    _surveyAdressGetter.GetSurveyAdress(locationList.Count + 45),
                    CompletionStatus.TODO);
                locationList.Add(surveyLocation);
            } while (locationList.Count < 4 && _questionHelper.AskYesNoQuestion("Do you want to add another survey location ?"));
            return locationList;
        }
    }
}
