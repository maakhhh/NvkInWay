namespace app;

public partial class AuthorizationPage : ContentPage
{
    public AuthorizationPage()
    {
        InitializeComponent();
    }
    
    private async void OnSwitchToRegistrationClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegistrationPage());
    }
    
    private void OnRegistrationClicked(object sender, EventArgs e)
    {
    }
}