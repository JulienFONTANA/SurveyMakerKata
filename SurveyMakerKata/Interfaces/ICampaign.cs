using System.Collections.Generic;

namespace SurveyMakerKata
{
    public interface ICampaign
    {
        int Id { get; set; }
        ISurvey Survey { get; set; }
        List<ISurveyLocations> Adresses { get; set; }
    }
}