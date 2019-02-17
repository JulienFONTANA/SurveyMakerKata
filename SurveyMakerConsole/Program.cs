using Newtonsoft.Json;
using SurveyMakerKata;
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

            using (StreamWriter file = File.CreateText(@"D:\Survey.json"))
            {
                serializer.Serialize(file, campaign.Survey);
            }

            using (StreamWriter file = File.CreateText(@"D:\Campaign.json"))
            {
                serializer.Serialize(file, campaign);
            }
        }
    }
}
