namespace SurveyMakerKata
{
    public class SurveyAdressGetter : ISurveyAdressGetter
    {
        private readonly IQuestionHelper _questionHelper;

        public SurveyAdressGetter(IQuestionHelper questionHelper)
        {
            _questionHelper = questionHelper;
        }

        public SurveyAdress GetSurveyAdress(int id, bool isClientAdress = false)
        {
            var firstQuestion = isClientAdress ? "Where does the client lives ? " : "Where would you like to ask questions ? ";

            var numVoieStr = _questionHelper.AskQuestion(firstQuestion + "Give street number :");
            int.TryParse(numVoieStr, out int numVoie);

            var nomVoie = _questionHelper.AskQuestion("Where would you like to ask questions ? Give street name :");
            var zipCode = _questionHelper.AskQuestion("Where would you like to ask questions ? Give zip code :");
            var city = _questionHelper.AskQuestion("Where would you like to ask questions ? Give city name :");

            return new SurveyAdress(id, numVoie, nomVoie, zipCode, city);
        }
    }
}
