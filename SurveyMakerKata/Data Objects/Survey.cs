using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class Survey : ISurvey
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string ClientName { get; set; }
        public string ClientAdress { get; set; }
        public List<ISurveyQuestion> QuestionList { get; set; }
    }
}
