namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        if (Application.Current is App app)
        {
            PropriedadesApp = app;
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;
        }

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);

        // Verifica se a data possui valor
        if (dtpck_checkin.Date != null)
        {
            dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
            dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new HospedagemContratada());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new QuemSomos());
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (sender is DatePicker elemento)
        {
            DateTime dataSelecionadaCheckin = (DateTime)elemento.Date;

            dtpck_checkout.MinimumDate = dataSelecionadaCheckin.AddDays(1);
            dtpck_checkout.MaximumDate = dataSelecionadaCheckin.AddMonths(6);
        }
    }
}