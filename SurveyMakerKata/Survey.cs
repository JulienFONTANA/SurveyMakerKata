using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class Survey
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string ClientName { get; set; }
        public string ClientAdress { get; set; }
        public List<SurveyQuestion> QuestionList { get; set; }
    }
}
