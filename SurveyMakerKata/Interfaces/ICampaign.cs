using System.Collections.Generic;

namespace SurveyMakerKata
{
    public interface ICampaign
    {
        int Id { get; set; }
        int SurveyId { get; set; }
        List<ISurveyLocations> Adresses { get; set; }
    }
}