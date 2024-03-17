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


namespace camera.ui.maui.Pages
{
    public partial class LoginPage : ContentPage
    {
        IWebService WebService;

        public LoginPage(IServiceProvider provider)
        {
            InitializeComponent();

            WebService = provider.GetService<IWebService>();
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
                await Shell.Current.GoToAsync("//CamerasPage");
            }
            catch (Exception ex)
            {
                LoginBtn.IsVisible = true;
                ActivityIndicator.IsVisible = false;

                DisplayToast(ex.Message);
            }
        }
    }
}
