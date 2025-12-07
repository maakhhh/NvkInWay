namespace app;

public partial class RegistrationPage : ContentPage
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void OnSwitchToAuthorizationClicked(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new AuthorizationPage());
    }
    
    private void OnAuthorizationClicked(object? sender, EventArgs e)
    {
    }
}