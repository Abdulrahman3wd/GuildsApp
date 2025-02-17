using GuildsApp.Services;
using GuildsApp.ViewModels;
using System.Collections.ObjectModel;

namespace GuildsApp.Pages;

public partial class ListOfGuildsPage : ContentPage
{
	public ListOfGuildsPage()
	{
		InitializeComponent();
        BindingContext = new ListOfGuildsViewModel(new GuildServices(new HttpClient()));

	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ListOfGuildsViewModel viewModel)
        {
            await viewModel.LoadData();
        }
    }

    private async void OnBackButtonTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}