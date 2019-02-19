using NUnit.Framework;
using NFluent;
using SurveyMakerKata;
using NSubstitute;

namespace SurveyMakerKataTest
{
    [TestFixture]
    public class SurveyCampaignMakerTest
    {
        public ISurveyCampaignMaker surveyCampaignMaker;
        public IQuestionHelper questionHelper;

        [SetUp]
        public void SetUp()
        {
            questionHelper = Substitute.For<IQuestionHelper>();

            questionHelper.AskQuestion(Arg.Any<string>()).Returns("AnswerToAskQuestion");
            questionHelper.AskOptionalQuestion(Arg.Any<string>()).Returns("AnswerToAskOptionalQuestion");
            questionHelper.AskYesNoQuestion(Arg.Any<string>()).Returns(true);

            var surveyAdressGetter = Substitute.For<ISurveyAdressGetter>();

            surveyCampaignMaker = new SurveyCampaignMaker(questionHelper, surveyAdressGetter);
        }

        [Test]
        public void Should_Call_AskQuestion_Method()
        {
            surveyCampaignMaker.CreateNewCampaign();

            Check.That(questionHelper.Received().AskQuestion(Arg.Any<string>()));
        }
        
        [Test]
        public void Should_Call_AskOptionalQuestion_Method()
        {
            surveyCampaignMaker.CreateNewCampaign();

            Check.That(questionHelper.Received().AskOptionalQuestion(Arg.Any<string>()));
        }
        
        [Test]
        public void Should_Call_AskYesNoQuestion_Method()
        {
            surveyCampaignMaker.CreateNewCampaign();

            Check.That(questionHelper.Received().AskYesNoQuestion(Arg.Any<string>()));
        }
    }
}
