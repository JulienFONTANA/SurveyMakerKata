using System;
using System.Collections.Generic;

namespace SurveyMakerKata
{
    public class Survey : ISurvey
    {
        public Survey(int id, string summary, string clientName, string clientAdress, List<ISurveyQuestion> questionList)
        {
            Id = id;
            Summary = summary;
            ClientName = clientName;
            ClientAdress = clientAdress;
            QuestionList = questionList;
        }

        public Survey(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string Summary { get; set; }
        public string ClientName { get; set; }
        public string ClientAdress { get; set; }
        public List<ISurveyQuestion> QuestionList { get; set; }
    }
}
