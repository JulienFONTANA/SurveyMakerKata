namespace SurveyMakerKata
{
    public interface IQuestionHelper
    {
        string AskOptionalQuestion(string question);
        string AskQuestion(string question);
        bool AskYesNoQuestion(string question);
    }
}