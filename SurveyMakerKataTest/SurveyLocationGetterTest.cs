using NUnit.Framework;
using NFluent;
using SurveyMakerKata;
using NSubstitute;
using System.Linq;

namespace SurveyMakerKataTest
{
    [TestFixture]
    public class SurveyLocationGetterTest
    {
        public IQuestionHelper questionHelper = Substitute.For<IQuestionHelper>();
        public ISurveyAdressGetter surveyAdressGetter = Substitute.For<ISurveyAdressGetter>();
        public ISurveyLocationGetter surveyLocationGetter;

        public ISurveyAdress expectedSurveyAdress;
        public ISurveyLocations expectedSurveyLocation;

        [SetUp]
        public void SetUp()
        {
            expectedSurveyAdress = new SurveyAdress(46, 7, "rue du temple", "75002", "Paris");
            expectedSurveyLocation = new SurveyLocations(100, expectedSurveyAdress, CompletionStatus.TODO);

            questionHelper.AskYesNoQuestion(Arg.Any<string>()).Returns(false);
            surveyAdressGetter.GetSurveyAdress(Arg.Any<int>(), false).Returns(expectedSurveyAdress);

            surveyLocationGetter = new SurveyLocationGetter(questionHelper, surveyAdressGetter);
        }

        [Test]
        public void Should_Have_Expected_SurveyLocation_When_GetSurveyLocation_Method_Is_Called()
        {
            var actual = surveyLocationGetter.GetSurveyLocation();

            Check.That(actual.First()).HasFieldsWithSameValues(expectedSurveyLocation);
        }
    }
}
