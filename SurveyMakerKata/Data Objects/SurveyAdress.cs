using System;

namespace SurveyMakerKata
{
    public  class SurveyAdress : ISurveyAdress
    {
        public SurveyAdress(int id, int numVoie, string nomVoie, string zipCode, string cityName)
        {
            Id = id;
            NumVoie = numVoie;
            NomVoie = nomVoie ?? throw new ArgumentNullException(nameof(nomVoie));
            ZipCode = zipCode;
            CityName = cityName;
        }

        public int Id { get; set; }
        public int NumVoie { get; set; }
        public string NomVoie { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
    }
}