using System.Runtime.CompilerServices;

namespace DemoApp.Settings
{
    public interface ISettings
    {
        TValue Get<TValue>(TValue defaultValue, [CallerMemberName] string propertyName = "");

        bool Set<TValue>(TValue value, [CallerMemberName] string propertyName = "");
    }
}
