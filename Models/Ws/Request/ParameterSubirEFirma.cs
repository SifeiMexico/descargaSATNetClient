using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request {
   public class ParameterSubirEFirma {
        [JsonProperty(PropertyName = "cert")]
        public string Cert { get; set; }
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        [JsonProperty(PropertyName = "pass")]
        public string KeyPass { get; set; }
    }
}
