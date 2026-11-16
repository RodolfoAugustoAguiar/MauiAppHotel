namespace MauiAppHotel.Views;

public partial class QuemSomos : ContentPage
{
	public QuemSomos()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ContratacaoHospedagem());
    }
}