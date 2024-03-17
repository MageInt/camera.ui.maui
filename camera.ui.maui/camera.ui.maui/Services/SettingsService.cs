using camera.ui.maui.Enums;
using camera.ui.maui.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace camera.ui.maui.Services
{
    class SettingsService : ISettingsService
    {
        public const string USER = "USER";
        public const string PASSWORD = "PASSWORD";
        public const string BASE_URL = "BASE_URL";

        public SettingsService()
        {

        }

        public async Task Initialiaze()
        {
            await InitSetting(SettingsEnum.USER);
            await InitSetting(SettingsEnum.PASSWORD);
            await InitSetting(SettingsEnum.BASE_URL);
        }

        private async Task InitSetting(SettingsEnum key, string value = "")
        {
            if (GetSecureString(key) == null)
                await SetSecureString(key, value);
        }

        public async Task SetSecureString(SettingsEnum key, string value)
        {
            await SecureStorage.Default.SetAsync(key.ToString(), value);
        }

        public async Task<string> GetSecureString(SettingsEnum key)
        {
            return await SecureStorage.Default.GetAsync(key.ToString());
        }
    }
}
