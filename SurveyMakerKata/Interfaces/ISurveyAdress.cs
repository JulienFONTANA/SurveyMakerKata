namespace SurveyMakerKata
{
    public interface ISurveyAdress
    {
        int Id { get; set; }
        string NomVoie { get; set; }
        int NumVoie { get; set; }
        int CodePostal { get; set; }
        int Commmune { get; set; }
    }
}