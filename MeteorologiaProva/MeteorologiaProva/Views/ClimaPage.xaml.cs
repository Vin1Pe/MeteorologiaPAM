using MeteorologiaProva.Views;
using MeteorologyPrevision.ViewModel;
using Microsoft.Maui.Graphics.Text;


namespace MeteorologiaProva.Views;

public partial class ClimaPage : ContentPage
{
    private MeteorologyViewModel viewModel;
    public ClimaPage()
    {
        InitializeComponent();
        viewModel = new MeteorologyViewModel();
        BindingContext = viewModel;
    }



    private async void LocationEntry_Completed(object sender, EventArgs e)
    {
        string LocationText = ((Entry)sender).Text;

        if (LocationText == null)
        {
            DisplayAlert("Erro","Tu n digitou nada", "Ok");
            return;
        }

        await viewModel.getClimates(LocationText);
    }
}