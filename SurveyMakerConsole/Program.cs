﻿using Newtonsoft.Json;
using SurveyMakerKata;
using System;
using System.IO;

namespace SurveyMakerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var questionHelper = new QuestionHelper();
            var surveyAdressGetter = new SurveyAdressGetter(questionHelper);

            var surveyCM = new SurveyCampaignMaker(questionHelper, surveyAdressGetter);
            var campaign = surveyCM.CreateNewCampaign();

            var serializer = new JsonSerializer();

            using (StreamWriter file = File.CreateText(@"C:\Users\jfont\Source\Repos\SurveyMakerKata\SurveyMakerConsole\output\Survey.json"))
            {
                serializer.Serialize(file, campaign.Survey);
            }

            using (StreamWriter file = File.CreateText(@"C:\Users\jfont\Source\Repos\SurveyMakerKata\SurveyMakerConsole\output\Campaign.json"))
            {
                serializer.Serialize(file, campaign);
            }

            Console.WriteLine("Survey exported to JSON format !");
        }
    }
}
