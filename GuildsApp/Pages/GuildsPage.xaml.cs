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

    //private void OnGridTapped(object sender, EventArgs e)
    //{
    //    ExpandableContent.IsVisible = !ExpandableContent.IsVisible;
    //    ArrowIcon.Source = ExpandableContent.IsVisible ? "arrowup.png" : "arrowdown.png";

    //}
}