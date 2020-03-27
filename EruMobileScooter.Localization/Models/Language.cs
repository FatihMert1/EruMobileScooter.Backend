

namespace EruMobileScooter.Localization.Models
{
    public class Language : ILanguage
    {

        private readonly Translator translator;

        public Language(Translator translator)
        {
            this.translator = translator;
        }

        // Fails
        public string Failled => translator.GetString(nameof(Failled), arguments);
        // Errors
        public string WrongInput => translator.GetString(nameof(WrongInput),arguments);

        // Success
        public string Success => translator.GetString(nameof(Success));

        private object[] arguments = null;
        public ILanguage SetArguments(params object[] arguments)
        {
            this.arguments = null;
            this.arguments = arguments;
            return this;
        }
    }


    public interface ILanguage
    {
        // Fails
        string Failled { get; }

        // Errors
        string WrongInput { get; }

        // Warnings

        // Success
        string Success { get; }

        ILanguage SetArguments(params object[] arguments);
    }
}
