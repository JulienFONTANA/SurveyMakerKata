using System.Collections.Generic;

namespace SurveyMakerKata
{
    public interface ICampaign
    {
        int Id { get; set; }
        int ISurvey { get; set; }
        List<ISurveyLocations> Adresses { get; set; }
    }
}