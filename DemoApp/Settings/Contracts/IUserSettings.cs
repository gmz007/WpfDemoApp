namespace DemoApp.Settings
{
    public interface IUserSettings : ISettings
    {
        string Language { get; set; }
    }
}
