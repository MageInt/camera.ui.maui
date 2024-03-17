using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace camera.ui.maui.DTO
{
    public class POSTLoginDTO
    {
        [JsonProperty("username", Required = Required.Always)]
        public string? username { get; set; }
        [JsonProperty("password", Required = Required.Always)]
        public string? password { get; set; }
    }
}
