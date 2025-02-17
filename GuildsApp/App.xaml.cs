using GuildsApp.Pages;
using GuildsApp.Services;
using GuildsApp.ViewModels;

namespace GuildsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
