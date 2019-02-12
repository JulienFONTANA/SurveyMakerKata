namespace SurveyMakerKata
{
    public class SurveyLocations : ISurveyLocations
    {
        public int Id { get; set; }
        public ISurveyAdress Adress { get; set; }
        public CompletionStatus Status { get; set; }
    }
} 