namespace SurveyMakerKata
{
    public interface ISurveyAdress
    {
        int Id { get; set; }
        string NomVoie { get; set; }
        int NumVoie { get; set; }
        string ZipCode { get; set; }
        string CityName { get; set; }
    }
}