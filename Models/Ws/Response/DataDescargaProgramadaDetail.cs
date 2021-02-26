using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Response {
  public  class DataDescargaProgramadaDetail : DataDescargaProgramada {
        private DateTime? fechaOrigenProgramacion;

        private int? cfdiDescargados;

        private DateTime? ultimaEjecucion;

        private String metodoDescarga;

        private String metodoDescargaString;



        private String rfcEmisor;
        private String rfcReceptor;

        private String tipoDeDescarga;
        

        public DateTime? FechaOrigenProgramacion { get => fechaOrigenProgramacion; set => fechaOrigenProgramacion = value; }
        public int? CfdiDescargados { get => cfdiDescargados; set => cfdiDescargados = value; }
        public DateTime? UltimaEjecucion { get => ultimaEjecucion; set => ultimaEjecucion = value; }
        public string MetodoDescarga { get => metodoDescarga; set => metodoDescarga = value; }
        public string MetodoDescargaString { get => metodoDescargaString; set => metodoDescargaString = value; }
        public string RfcEmisor { get => rfcEmisor; set => rfcEmisor = value; }
        public string RfcReceptor { get => rfcReceptor; set => rfcReceptor = value; }
        public string TipoDeDescarga { get => tipoDeDescarga; set => tipoDeDescarga = value; }
        
    }
}
