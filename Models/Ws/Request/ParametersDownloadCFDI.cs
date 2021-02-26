using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request {
  public  class ParametersDownloadCFDI {
        public ParametersDownloadCFDI() {

            this.EmitidoRecibido = EmitidoRecibidoType.Todos;
        }

        private DateTime? fechaFinal;

        private DateTime? fechaInicial;

        private string efectoCFDI;

        private EmitidoRecibidoType emitidoRecibido;
        [JsonProperty(PropertyName = "fechaFinal")]
        public DateTime? FechaFinal { get => fechaFinal; set => fechaFinal = value; }
        [JsonProperty(PropertyName = "fechaInicial")]
        public DateTime? FechaInicial { get => fechaInicial; set => fechaInicial = value; }
        [JsonProperty(PropertyName = "efectoCFDI")]
        public string EfectoCFDI { get => efectoCFDI; set => efectoCFDI = value; }

        [JsonProperty(PropertyName = "emitidoRecibido")]
        public EmitidoRecibidoType EmitidoRecibido { get => emitidoRecibido; set => emitidoRecibido = value; }

        public enum EmitidoRecibidoType {
            Todos=-1,
            Emitidos=1,
            Recibido=2
        }
    }
}
