using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class Campaign : ICampaign
    {
        public Campaign(ISurvey survey, List<ISurveyLocations> locations)
        {
            Survey = survey;
            Adresses = locations;
        }

        public int Id { get; set; }
        public ISurvey Survey { get; set; }
        public List<ISurveyLocations> Adresses { get; set; }
    }
}