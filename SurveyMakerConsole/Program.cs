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
            var surveyCM = new SurveyCampaignMaker();
            var campaign = surveyCM.CreateNewCampaign();

            var serializer = new JsonSerializer();

            using (StreamWriter file = File.CreateText(@"D:\SurveyOnly.txt"))
            {
                serializer.Serialize(file, campaign.Survey);
            }
            //using (StreamWriter file = File.CreateText(@"D:\Campaign.txt"))
            //{
            //    var tmpCampaign = campaign;
            //    tmpCampaign.Survey = new Survey(campaign.Survey.Id);
            //    serializer.Serialize(file, campaign.Survey);
            //}

            Console.ReadKey();
        }
    }
}
