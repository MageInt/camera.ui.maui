using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using camera.ui.maui.DTO;
using Newtonsoft.Json;
using Microsoft.Maui;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;
using Application = Microsoft.Maui.Controls.Application;
using camera.ui.maui.ViewModels;
using camera.ui.maui.Interfaces;
using camera.ui.maui.Enums;


namespace camera.ui.maui.Pages
{
    public partial class LoginPage : ContentPage
    {
        IWebService WebService;
        ISettingsService SettingsService;

        public LoginPage(IServiceProvider provider)
        {
            InitializeComponent();

            WebService = provider.GetService<IWebService>();
            SettingsService = provider.GetService<ISettingsService>();

            Loaded += LoginPage_Loaded;
        }

        private async void LoginPage_Loaded(object? sender, EventArgs e)
        {
            await SettingsService.Initialiaze();

            EntryUser.Text = await SettingsService.GetSecureString(SettingsEnum.USER);
            EntryPassword.Text = await SettingsService.GetSecureString(SettingsEnum.PASSWORD);
            EntryBaseUrl.Text = await SettingsService.GetSecureString(SettingsEnum.BASE_URL);
        }

        private async void DisplayToast(string message)
        {
            var toast = Toast.Make(message, CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toast.Show();
        }

        private async void OnLoginBtnClicked(object sender, EventArgs e)
        {
            try
            {
                LoginBtn.IsVisible = false;
                ActivityIndicator.IsVisible = true;

                await WebService.Login(EntryUser.Text, EntryPassword.Text, EntryBaseUrl.Text);

                //Save Login infos
                await SettingsService.SetSecureString(SettingsEnum.USER, EntryUser.Text);
                await SettingsService.SetSecureString(SettingsEnum.PASSWORD, EntryPassword.Text);
                await SettingsService.SetSecureString(SettingsEnum.BASE_URL, EntryBaseUrl.Text);

                await Shell.Current.GoToAsync("//main");
            }
            catch (Exception ex)
            {
                LoginBtn.IsVisible = true;
                ActivityIndicator.IsVisible = false;

                Debug.WriteLine($"{ex.Message} - {ex.StackTrace}");
                DisplayToast(ex.Message);
            }
        }
    }
}
