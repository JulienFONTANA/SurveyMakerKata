using NUnit.Framework;
using NFluent;
using SurveyMakerKata;
using NSubstitute;

namespace SurveyMakerKataTest
{
    [TestFixture]
    public class SurveyAdressGetterTest
    {
        public IQuestionHelper questionHelper = Substitute.For<IQuestionHelper>();
        public ISurveyAdressGetter surveyAdressGetter;

        [SetUp]
        public void SetUp()
        {
            questionHelper.AskQuestion(Arg.Any<string>()).Returns("AnswerToAskQuestion");

            surveyAdressGetter = new SurveyAdressGetter(questionHelper);
        }

        [Test]
        public void Should_Call_AskQuestion_Method()
        {
            var actual = surveyAdressGetter.GetSurveyAdress(123, false);

            Check.That(actual.Id).IsEqualTo(123);
        }
    }
}
