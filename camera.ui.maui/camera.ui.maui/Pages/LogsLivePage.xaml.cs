using camera.ui.maui.DTO;
using camera.ui.maui.Interfaces;

namespace camera.ui.maui.Pages;

public partial class LogsLivePage : ContentPage
{
    LogsSocketConfigDTO LogsSocketConfigDTO;
    IWebService WebService;
    public LogsLivePage(IServiceProvider provider)
	{
		InitializeComponent();

        WebService = provider.GetService<IWebService>();

        Loaded += LogsLivePage_Loaded;
    }

    private async void LogsLivePage_Loaded(object? sender, EventArgs e)
    {
        LogsSocketConfigDTO = await WebService.GetLogsSocketConfig();



    }
}