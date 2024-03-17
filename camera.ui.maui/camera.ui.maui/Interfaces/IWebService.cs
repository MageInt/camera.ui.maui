using camera.ui.maui.DTO;

namespace camera.ui.maui.Interfaces
{
    public interface IWebService
    {
        Task<List<Camera>> GetCameras();
        Task<LogsSocketConfigDTO> GetLogsSocketConfig();
        Task<string> GetLogs();
        Task Login(string username, string password, string baseURL);
        HttpClient AuthenticatedHttpClient { get; }
    }
}