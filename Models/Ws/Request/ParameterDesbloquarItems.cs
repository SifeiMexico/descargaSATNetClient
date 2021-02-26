using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request {
    public class ParameterDesbloquarItems {
        [JsonProperty(PropertyName = "TipoDesbloqueo")]
        public string TipoDesbloqueo { get; set; }

        public ParameterDesbloquarItems() {
            TipoDesbloqueo = TIPO_DESBLOQUEO.CFDI;
        }
       
        
    }
    public static class TIPO_DESBLOQUEO {
        public static String CFDI = "CFDI";
        public static String META = "META";        
    }
}
