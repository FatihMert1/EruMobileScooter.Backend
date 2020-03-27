

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
        public string Failled => translator.GetString(nameof(Failled));
        public string AlreadyCreated => translator.GetString(nameof(AlreadyCreated));
        // Errors
        public string WrongInput => translator.GetString(nameof(WrongInput));

        // Success
        public string Success => translator.GetString(nameof(Success));

    }


    public interface ILanguage
    {
        // Fails
        string Failled { get; }
        string AlreadyCreated { get; }  

        // Errors
        string WrongInput { get; }

        // Warnings

        // Success
        string Success { get; }
    }
}
