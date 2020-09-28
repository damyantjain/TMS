using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Model
{
    public class AppConfiguration
    {
        [JsonProperty("AwsPoolId")]
        public string AwsPoolId { get; set; }
        
        [JsonProperty("SyncfusionKey")]
        public string SyncfusionKey { get; set; }
        
        [JsonProperty("FireBaseUrl")]
        public string FireBaseUrl { get; set; }

    }
}
