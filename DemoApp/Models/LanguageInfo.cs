namespace DemoApp.Models
{
    public class LanguageInfo
    {
        public string FullName { get; }

        public string Code { get; }

        public Uri IconUri { get; }

        public LanguageInfo(string name, string code, Uri imageSource)
        {
            FullName = name;
            Code = code;
            IconUri = imageSource;
        }
    }
}
