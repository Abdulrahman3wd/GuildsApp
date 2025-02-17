using GuildsApp.Pages;

namespace GuildsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreateGuildPage), typeof(CreateGuildPage));
            Routing.RegisterRoute(nameof(GuildsPage), typeof(GuildsPage));
            Routing.RegisterRoute(nameof(ListOfGuildsPage), typeof(ListOfGuildsPage));
        }

    }
}
