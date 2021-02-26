using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request {
    public class DescargaProgramadaRequest {
        public DescargaProgramadaRequest() {
            tipodeDescargaDescarga = TipoDescarga.CFDI;
        }


        private DateTime fechaInicial;


        private DateTime fechaFinal;

        private TipoDescarga tipodeDescargaDescarga;

        public DateTime FechaInicial { get => fechaInicial; set => fechaInicial = value; }
        public DateTime FechaFinal { get => fechaFinal; set => fechaFinal = value; }

        [JsonProperty(PropertyName = "TipoDeDescarga")]
        public TipoDescarga TipodeDescargaDescarga { get => tipodeDescargaDescarga; set => tipodeDescargaDescarga = value; }

        public enum TipoDescarga {
            CFDI = 1,
            META = 2
        }
    }
}
