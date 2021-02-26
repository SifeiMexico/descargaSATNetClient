using DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request {
    public class ParametersDescargasDiarias {
        public ParametersDescargasDiarias() {
            estadoDescarga = ESTADO.TODOS;
        }
        public string estadoDescarga;

        public TIPO_DESCARGA? tipoDescarga;

        public METODO_DESCARGA? metodoDescarga;

        public DateTime? fechaInicial;

        public DateTime? fechaFinal;



       
    }
    public enum METODO_DESCARGA {
        IGNORE = 0,
        PORTAL = 1,
        OFICIAL = 2
    }

    public enum TIPO_DESCARGA {
        IGNORE = 0,
        CFDI = 1,
        META = 2
    }
}
