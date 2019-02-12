﻿using System.Collections.Generic;

namespace SurveyMakerKata
{
    public interface ISurvey
    {
        int Id { get; set; }
        string Summary { get; set; }
        string ClientName { get; set; }
        string ClientAdress { get; set; }
        List<ISurveyQuestion> QuestionList { get; set; }
    }
}