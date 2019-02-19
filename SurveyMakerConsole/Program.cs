using Newtonsoft.Json;
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
            var surveyCM = new SurveyCampaignMaker(questionHelper);
            var campaign = surveyCM.CreateNewCampaign();

            var serializer = new JsonSerializer();

            using (StreamWriter file = File.CreateText(@"D:\Survey.json"))
            {
                serializer.Serialize(file, campaign.Survey);
            }

            using (StreamWriter file = File.CreateText(@"D:\Campaign.json"))
            {
                serializer.Serialize(file, campaign);
            }

            Console.WriteLine("Survey exported to JSON format !");
        }
    }
}
