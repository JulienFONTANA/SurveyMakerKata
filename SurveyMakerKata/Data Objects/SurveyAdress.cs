using System;

namespace SurveyMakerKata
{
    public  class SurveyAdress : ISurveyAdress
    {
        public SurveyAdress(int id, int numVoie, string nomVoie, string codePostal, string commmune)
        {
            Id = id;
            NumVoie = numVoie;
            NomVoie = nomVoie ?? throw new ArgumentNullException(nameof(nomVoie));
            CodePostal = codePostal;
            Commmune = commmune;
        }

        public int Id { get; set; }
        public int NumVoie { get; set; }
        public string NomVoie { get; set; }
        public string CodePostal { get; set; }
        public string Commmune { get; set; }
    }
}