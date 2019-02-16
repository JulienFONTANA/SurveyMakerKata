namespace SurveyMakerKata
{
    public interface ISurveyAdress
    {
        int Id { get; set; }
        string NomVoie { get; set; }
        int NumVoie { get; set; }
        string CodePostal { get; set; }
        string Commmune { get; set; }
    }
}