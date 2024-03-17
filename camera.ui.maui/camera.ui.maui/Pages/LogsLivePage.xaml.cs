using camera.ui.maui.DTO;
using camera.ui.maui.Interfaces;
using SocketIOClient;
using System.Diagnostics;

namespace camera.ui.maui.Pages;

public partial class LogsLivePage : ContentPage
{
    LogsSocketConfigDTO LogsSocketConfigDTO;
    IWebService WebService;
    string Logs;

    public LogsLivePage(IServiceProvider provider)
	{
		InitializeComponent();

        WebService = provider.GetService<IWebService>();

        Loaded += LogsLivePage_Loaded;
    }

    private void LogsLivePage_Loaded(object? sender, EventArgs e)
    {
        Task.Run(async () =>
        {

            if(Logs == null)
            {
                Logs = await WebService.GetLogs();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LogsLabel.Text = Logs;
                });
            }

            //LogsSocketConfigDTO = await WebService.GetLogsSocketConfig();
            //string BaseUrl = WebService.AuthenticatedHttpClient.BaseAddress.ToString();

            //Client client = new(BaseUrl + $"socket.io/?EIO=4&transport=polling&t=OvB-R-6&sid={LogsSocketConfigDTO.sid}");

            //client.On("logMessage", (data) => {

            //    LogsLabel.Text += data + Environment.NewLine;
            //    Debug.WriteLine(data);
            //});
        });
    }
}