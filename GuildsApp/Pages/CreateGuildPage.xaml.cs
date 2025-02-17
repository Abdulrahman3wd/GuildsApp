using GuildsApp.ViewModels;

namespace GuildsApp.Pages;

public partial class CreateGuildPage : ContentPage
{

    public CreateGuildPage(CreateGuildViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}

    private async void OnBackButtonTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}