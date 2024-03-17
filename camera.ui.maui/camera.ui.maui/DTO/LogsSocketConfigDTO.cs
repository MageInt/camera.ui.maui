using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace camera.ui.maui.DTO
{
    public class LogsSocketConfigDTO
    {
        [JsonProperty("sid")]
        public string sid { get; set; }

        [JsonProperty("upgrades")]
        public List<string> upgrades { get; set; }

        [JsonProperty("pingInterval")]
        public int pingInterval { get; set; }

        [JsonProperty("pingTimeout")]
        public int pingTimeout { get; set; }

        [JsonProperty("maxPayload")]
        public int maxPayload { get; set; }
    }
}
