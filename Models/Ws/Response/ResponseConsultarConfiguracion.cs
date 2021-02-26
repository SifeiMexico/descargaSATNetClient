using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Response {
    public class ResponseConsultarConfiguracion {
        [JsonProperty(PropertyName = "metodoDescarga")]
        public string MetodoDescarga { get; set; }
        [JsonProperty(PropertyName = "horasEsperaWs")]
        public int HorasEsperaWs { get; set; }
        [JsonProperty(PropertyName = "horasEsperaPortal")]
        public int HorasEsperaPortal { get; set; }
        [JsonProperty(PropertyName = "mensaje")]
        public string Mensaje { get; set; }
    }
}
