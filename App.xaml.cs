using Avalonia;
using Avalonia.Markup.Xaml;

namespace SynkNote_Desktop
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
   }
}