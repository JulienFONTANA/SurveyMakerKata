using System.Collections.Generic;

namespace SurveyMakerKata
{
    public interface ISurveyLocationGetter
    {
        List<ISurveyLocations> GetSurveyLocation();
    }
}