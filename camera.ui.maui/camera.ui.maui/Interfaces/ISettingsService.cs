
using camera.ui.maui.Enums;

namespace camera.ui.maui.Interfaces
{
    public interface ISettingsService
    {
        Task<string> GetSecureString(SettingsEnum key);
        Task Initialiaze();
        Task SetSecureString(SettingsEnum key, string value);
    }
}