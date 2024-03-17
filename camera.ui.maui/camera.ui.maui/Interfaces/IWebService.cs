using camera.ui.maui.DTO;

namespace camera.ui.maui.Interfaces
{
    public interface IWebService
    {
        Task<List<Camera>> GetCameras();
        Task Login(string username, string password, string baseURL);
    }
}