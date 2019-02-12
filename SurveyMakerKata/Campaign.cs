using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class Campaign
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public List<SurveyLocations> Adresses { get; set; }
    }
}