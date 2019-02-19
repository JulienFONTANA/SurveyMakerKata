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
        public ISurveyAdressGetter surveyAdressGetter;

        public SurveyAdress ExpectedSurveyAdress { get; set; }

        [SetUp]
        public void SetUp()
        {
            ExpectedSurveyAdress = new SurveyAdress(123, 7, "rue de Rivoli", "75000", "Paris");

            questionHelper = Substitute.For<IQuestionHelper>();
            questionHelper.AskQuestion(Arg.Any<string>()).Returns("AnswerToAskQuestion");
            questionHelper.AskOptionalQuestion(Arg.Any<string>()).Returns("AnswerToAskOptionalQuestion");
            questionHelper.AskYesNoQuestion(Arg.Any<string>()).Returns(true);

            surveyAdressGetter = Substitute.For<ISurveyAdressGetter>();
            surveyAdressGetter.GetSurveyAdress(Arg.Any<int>(), true).Returns(ExpectedSurveyAdress);

            surveyCampaignMaker = new SurveyCampaignMaker(questionHelper, surveyAdressGetter);
        }

        [Test]
        public void Should_Return_Expected_Adress_When_SurveyAdressGetter_Method_Is_Called()
        {
            var actual = surveyCampaignMaker.CreateNewCampaign();

            Check.That(actual.Survey.ClientAdress).HasFieldsWithSameValues(ExpectedSurveyAdress);
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

        [Test]
        public void Should_Call_GetSurveyAdress_Method()
        {
            surveyCampaignMaker.CreateNewCampaign();

            Check.That(surveyAdressGetter.Received().GetSurveyAdress(123, true));
        }
    }
}
