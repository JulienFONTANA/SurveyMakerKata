using NUnit.Framework;
using NFluent;
using SurveyMakerKata;

namespace SurveyMakerKataTest
{
    [TestFixture]
    public class QuestionHelperTest
    {
        private readonly IQuestionHelper QuestionHelper = new QuestionHelper();

        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Check.That("Your first passing test");
        }
    }
}
