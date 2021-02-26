using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Response {
    public class DataEFirmaResponse {
        [JsonProperty(PropertyName = "rfc")]
        public string RFC { get; set; }
        [JsonProperty(PropertyName = "noSerie")]
        public string NoSerie { get; set; }
        [JsonProperty(PropertyName = "validFrom")]
        public DateTime ValidFrom { get; set; }
        [JsonProperty(PropertyName = "validTo")]
        public DateTime ValidTo { get; set; }

    }
}
