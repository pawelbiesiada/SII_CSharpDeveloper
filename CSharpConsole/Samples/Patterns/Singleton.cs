using System.Globalization;

namespace CSharpConsole.Samples.Patterns
{
    class Singleton
    {
        private static Singleton _instance;
        private CultureInfo _language = new CultureInfo("en-en");

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }

        private Singleton(){}

        public CultureInfo GetLanguage()
        {
            return _language;
        }
        public void SetLanguage(string culture)
        {
            _language = new CultureInfo(culture);
        }
    }
}
