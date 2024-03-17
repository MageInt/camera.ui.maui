using camera.ui.maui.DTO;
using camera.ui.maui.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace camera.ui.maui.Services
{
    public class WebService : IWebService
    {
        private const string GetCamerasUrl = "api/cameras?status=Online%2COffline";
        private const string LoginUrl = "api/auth/login";
        private const string LogsSocketConfigUrl = "socket.io/?EIO=4&transport=polling&t=OvB-Rxg";
        private const string LogUrl = "api/system/log";
        
        public HttpClient HttpClient;

        public HttpClient AuthenticatedHttpClient => HttpClient;

        public WebService()
        {
 
        }

        public async Task Login(string username, string password, string baseURL)
        {
            try
            {
                HttpClient = new HttpClient();
                HttpClient.BaseAddress = new(baseURL);

                POSTLoginDTO postLoginDTO = new POSTLoginDTO() { username = username, password = password };

                string postReturn = await PostRequest(LoginUrl, JsonConvert.SerializeObject(postLoginDTO));

                Debug.WriteLine(postReturn);

                AuthentificationLoginDTO authentificationLoginDTO = JsonConvert.DeserializeObject<AuthentificationLoginDTO>(postReturn);
                HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", authentificationLoginDTO.access_token);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }


        private async Task<string> PostRequest(string url, string json)
        {
            string returned;

            Debug.WriteLine($"url : {url}");
            Debug.WriteLine($"json : {json}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await HttpClient.PostAsync(url, content);
            returned = await result.Content.ReadAsStringAsync();

            Debug.WriteLine($"returned : {returned}");

            return returned;
        }

        private async Task<string> GetRequest(string url)
        {
            string returned;

            Debug.WriteLine($"url : {url}");
            var result = await HttpClient.GetAsync(url);
            returned = await result.Content.ReadAsStringAsync();

            Debug.WriteLine($"returned : {returned}");

            return returned;
        }
        public async Task<string> GetLogs()
        {
            try
            {
                return await GetRequest(LogUrl);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return "";
            }
        }

        public async Task<LogsSocketConfigDTO> GetLogsSocketConfig()
        {
            try
            {
                string result = await GetRequest(LogsSocketConfigUrl);
                result = result.Remove(0, 1);
                LogsSocketConfigDTO LogsSocketConfigDTO = JsonConvert.DeserializeObject<LogsSocketConfigDTO>(result);
                return LogsSocketConfigDTO;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new LogsSocketConfigDTO();
            }
        }

        public async Task<List<Camera>> GetCameras()
        {
            try
            {
                string result = await GetRequest(GetCamerasUrl);
                CamerasDTO CamerasDTO = JsonConvert.DeserializeObject<CamerasDTO>(result);
                return CamerasDTO?.cameras;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new List<Camera>();
            }
        }
    }
}
