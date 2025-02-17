using GuildsApp.Services;
using GuildsApp.ViewModels;

namespace GuildsApp.Pages;

public partial class GuildsPage : ContentPage
{

    public GuildsPage()
	{
		InitializeComponent();
        BindingContext = new GuildsViewModel(new GuildServices(new HttpClient()));

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is GuildsViewModel viewModel)
        {
            await viewModel.LoadData();  
        }
    }

    private async void GoToCreateGuild(object sender , EventArgs e)
    {
        var createGuildPage = Handler.MauiContext.Services.GetService<CreateGuildPage>();
        await Navigation.PushAsync(createGuildPage);
    }
    private async void OnGoToListTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListOfGuildsPage());
    }


}