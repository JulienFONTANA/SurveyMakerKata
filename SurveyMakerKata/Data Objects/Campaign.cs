using System.Collections.Generic;
using Newtonsoft.Json;

namespace SurveyMakerKata
{
    public class Campaign : ICampaign
    {
        public Campaign(ISurvey survey, List<ISurveyLocations> locations)
        {
            Id = 1;
            Survey = survey;
            Adresses = locations;
        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public List<ISurveyLocations> Adresses { get; set; }

        [JsonIgnore]
        public ISurvey Survey { get; set; }
    }
}