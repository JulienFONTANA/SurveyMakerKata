using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class Campaign : ICampaign
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public List<ISurveyLocations> Adresses { get; set; }
    }
}