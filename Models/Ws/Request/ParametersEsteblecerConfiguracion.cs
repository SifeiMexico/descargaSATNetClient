using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request {
  public   class ParametersEsteblecerConfiguracion {
        [JsonProperty(PropertyName = "horasEsperaPortal")]
        public int HorasEsperaPortal { get; set; }

        [JsonProperty(PropertyName = "horasEsperaWs")]
        public int HorasEsperaWs { get; set; }

        /// <summary>
        /// Parametro para endpoint metodo descarga
        /// </summary>
        [JsonProperty(PropertyName = "metodoDescarga")]
        public string MetodoDescarga { get; set; }


        public const string METODO_WS = "WS";
        public const string METODO_PORTAL = "PORTAL";
    }
}
