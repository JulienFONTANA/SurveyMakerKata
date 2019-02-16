using SurveyMakerKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyMakerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var surveyCM = new SurveyCampaignMaker();
            surveyCM.CreateNewCampaign();
        }
    }
}
