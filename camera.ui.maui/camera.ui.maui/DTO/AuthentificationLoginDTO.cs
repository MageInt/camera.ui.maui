using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace camera.ui.maui.DTO
{
    public class AuthentificationLoginDTO
    {
        [JsonProperty("access_token")]
        public string? access_token { get; set; }

        [JsonProperty("token_type")]
        public string? token_type { get; set; }

        [JsonProperty("expires_in")]
        public int expires_in { get; set; }

        [JsonProperty("expires_at")]
        public DateTime expires_at { get; set; }
    }
}
