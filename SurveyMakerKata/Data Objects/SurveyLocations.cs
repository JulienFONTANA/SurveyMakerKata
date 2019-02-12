namespace SurveyMakerKata
{
    public class SurveyLocations : ISurveyLocations
    {
        public SurveyLocations(int id, ISurveyAdress adress, CompletionStatus status)
        {
            Id = id;
            Adress = adress;
            Status = status;
        }

        public int Id { get; set; }
        public ISurveyAdress Adress { get; set; }
        public CompletionStatus Status { get; set; }
    }
} 