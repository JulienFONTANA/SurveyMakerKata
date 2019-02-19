namespace SurveyMakerKata
{
    public interface ISurveyAdressGetter
    {
        SurveyAdress GetSurveyAdress(int id, bool isClientAdress = false);
    }
}