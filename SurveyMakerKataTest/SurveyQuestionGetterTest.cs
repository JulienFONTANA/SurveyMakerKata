using NUnit.Framework;
using NFluent;
using SurveyMakerKata;
using NSubstitute;

namespace SurveyMakerKataTest
{
    [TestFixture]
    public class SurveyQuestionGetterTest
    {
        public IQuestionHelper questionHelper = Substitute.For<IQuestionHelper>();
        public ISurveyAdressGetter surveyAdressGetter = Substitute.For<ISurveyAdressGetter>();
        public ISurveyQuestionGetter surveyQuestionGetter;

        public ISurveyAdress expectedClientAdress;

        [SetUp]
        public void SetUp()
        {
            expectedClientAdress = new SurveyAdress(123, 7, "rue de Rivoli", "75000", "Paris");

            questionHelper.AskQuestion(Arg.Any<string>()).Returns("AnswerToAskQuestion");
            questionHelper.AskOptionalQuestion(Arg.Any<string>()).Returns("AnswerToAskOptionalQuestion");
            questionHelper.AskYesNoQuestion(Arg.Any<string>()).Returns(false);

            surveyAdressGetter.GetSurveyAdress(Arg.Any<int>(), true).Returns(expectedClientAdress);

            surveyQuestionGetter = new SurveyQuestionGetter(questionHelper, surveyAdressGetter);
        }

        [Test]
        public void Should_Have_Correct_Client_Adress()
        {
            var actual = surveyQuestionGetter.GetSurveyQuestion();

            Check.That(actual.ClientAdress).HasFieldsWithSameValues(expectedClientAdress);
        }

        [Test]
        public void Should_Have_Correct_Question_List_Size()
        {
            var actual = surveyQuestionGetter.GetSurveyQuestion();

            Check.That(actual.QuestionList.Count).IsEqualTo(1);
        }
    }
}
