namespace SurveyMakerKata
{
    public interface ISurveyLocations
    {
        int Id { get; set; }
        ISurveyAdress Adress { get; set; }
        CompletionStatus Status { get; set; }
    }
}