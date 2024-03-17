using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace camera.ui.maui.DTO
{
    public class CamerasDTO
    {
        [JsonProperty("pagination")]
        public Pagination pagination { get; set; }

        [JsonProperty("result")]
        public List<Camera> cameras { get; set; }
    }

    public class Mqtt
    {
    }

    public class Pagination
    {
        [JsonProperty("currentPage")]
        public int currentPage { get; set; }

        [JsonProperty("pageSize")]
        public int pageSize { get; set; }

        [JsonProperty("totalPages")]
        public int totalPages { get; set; }

        [JsonProperty("startIndex")]
        public int startIndex { get; set; }

        [JsonProperty("endIndex")]
        public int endIndex { get; set; }

        [JsonProperty("totalItems")]
        public int totalItems { get; set; }

        [JsonProperty("nextPage")]
        public object nextPage { get; set; }

        [JsonProperty("prevPage")]
        public object prevPage { get; set; }
    }

    public class Camera
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("motionTimeout")]
        public int motionTimeout { get; set; }

        [JsonProperty("recordOnMovement")]
        public bool recordOnMovement { get; set; }

        [JsonProperty("prebuffering")]
        public bool prebuffering { get; set; }

        [JsonProperty("videoConfig")]
        public VideoConfig videoConfig { get; set; }

        [JsonProperty("mqtt")]
        public Mqtt mqtt { get; set; }

        [JsonProperty("smtp")]
        public Smtp smtp { get; set; }

        [JsonProperty("videoanalysis")]
        public Videoanalysis videoanalysis { get; set; }

        [JsonProperty("prebufferLength")]
        public int prebufferLength { get; set; }
    }

    public class Smtp
    {
        [JsonProperty("email")]
        public string email { get; set; }
    }
    public class Videoanalysis
    {
        [JsonProperty("active")]
        public bool active { get; set; }
    }

    public class VideoConfig
    {
        [JsonProperty("source")]
        public string source { get; set; }

        [JsonProperty("stillImageSource")]
        public string stillImageSource { get; set; }

        [JsonProperty("stimeout")]
        public int stimeout { get; set; }

        [JsonProperty("audio")]
        public bool audio { get; set; }

        [JsonProperty("debug")]
        public bool debug { get; set; }

        [JsonProperty("subSource")]
        public string subSource { get; set; }

        [JsonProperty("rtspTransport")]
        public object rtspTransport { get; set; }

        [JsonProperty("vcodec")]
        public string vcodec { get; set; }

        [JsonProperty("acodec")]
        public string acodec { get; set; }

        [JsonProperty("maxFPS")]
        public int maxFPS { get; set; }

        [JsonProperty("maxWidth")]
        public int maxWidth { get; set; }

        [JsonProperty("maxHeight")]
        public int maxHeight { get; set; }
    }


}
