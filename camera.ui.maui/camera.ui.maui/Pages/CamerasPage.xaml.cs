using camera.ui.maui.Interfaces;
using System.Collections.ObjectModel;

namespace camera.ui.maui.Pages;

public partial class CamerasPage : ContentPage
{
    IWebService WebService;
    private List<DTO.Camera> Cameras;
    public CamerasPage(IServiceProvider provider)
	{
		InitializeComponent();
        WebService = provider.GetService<IWebService>();

        Loaded += CamerasPage_Loaded;
    }

    private async void CamerasPage_Loaded(object? sender, EventArgs e)
    {
        Cameras = await WebService.GetCameras();
       // ObservableCollection<DTO.Camera> cameras = new ObservableCollection<DTO.Camera>(Cameras);
        CamerasCollectionView.ItemsSource = Cameras;
    }

    public async void Logout()
	{
        await Shell.Current.GoToAsync("//LoginPage");
    }
}