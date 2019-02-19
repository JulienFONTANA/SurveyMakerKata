using NFluent;
using NSubstitute;
using NUnit.Framework;
using SurveyMakerKata;
using System.Collections.Generic;

namespace SurveyMakerKataTest
{
    [TestFixture]
    public class SurveyCampaignMakerTest
    {
        public ISurveyCampaignMaker surveyCampaignMaker;
        public IQuestionHelper questionHelper;
        public ISurveyLocationGetter surveyLocationGetter;
        public ISurveyQuestionGetter surveyQuestionGetter;

        public SurveyAdress ExpectedSurveyAdress { get; set; }
        public List<ISurveyLocations> ExpectedSurveyLocationList { get; set; }
        public List<ISurveyQuestion> ExpectedSurveyQuestionList { get; set; }
        public Survey ExpectedSurvey;

        [SetUp]
        public void SetUp()
        {
            ExpectedSurveyAdress = new SurveyAdress(123, 7, "rue de Rivoli", "75000", "Paris");
            ExpectedSurveyLocationList = new List<ISurveyLocations>
            {
                new SurveyLocations(100, ExpectedSurveyAdress, CompletionStatus.TODO)
            };
            ExpectedSurveyQuestionList = new List<ISurveyQuestion>
            {
                new SurveyQuestion { Id = 1, Question = "Q1"},
                new SurveyQuestion { Id = 2, Question = "Q2"},
            };
            ExpectedSurvey = new Survey(175, "AnswerToAskOptionalQuestion", "AnswerToAskQuestion", 
                ExpectedSurveyAdress, ExpectedSurveyQuestionList);

            questionHelper = Substitute.For<IQuestionHelper>();
            questionHelper.AskQuestion(Arg.Any<string>()).Returns("AnswerToAskQuestion");
            questionHelper.AskOptionalQuestion(Arg.Any<string>()).Returns("AnswerToAskOptionalQuestion");
            questionHelper.AskYesNoQuestion(Arg.Any<string>()).Returns(true);

            surveyLocationGetter = Substitute.For<ISurveyLocationGetter>();
            surveyLocationGetter.GetSurveyLocation().Returns(ExpectedSurveyLocationList);

            surveyQuestionGetter = Substitute.For<ISurveyQuestionGetter>();
            surveyQuestionGetter.GetSurveyQuestion().Returns(ExpectedSurvey);

            surveyCampaignMaker = new SurveyCampaignMaker(questionHelper, surveyLocationGetter, surveyQuestionGetter);
        }

        [Test]
        public void Should_Return_Expected_Survey_When_CreateNewCampaign_Is_Called()
        {
            var actual = surveyCampaignMaker.CreateNewCampaign();

            Check.That(actual.Survey).HasFieldsWithSameValues(ExpectedSurvey);
        }

        [Test]
        public void Should_Return_Expected_Adress_When_CreateNewCampaign_Is_Called()
        {
            var actual = surveyCampaignMaker.CreateNewCampaign();

            Check.That(actual.Adresses).HasFieldsWithSameValues(ExpectedSurveyLocationList);
        }

        [Test]
        public void Should_Call_AskYesNoQuestion_Method()
        {
            surveyCampaignMaker.CreateNewCampaign();

            Check.That(questionHelper.Received().AskYesNoQuestion(Arg.Any<string>()));
        }
    }
}
