using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Response {
 public   class CFDIModelAPI {
        private string uuid;
        private String rfcEmisor;
        private String rfcReceptor;
        private DateTime? fechaDescarga;
        private String total;
        private DateTime fechaEmision;
        private String pacquecertifico;
        private DateTime? fechaCertificacion;
        private Boolean disponibleXML;
        private Boolean disponibleMETA;
        private String solicitadaMetodo;
        private String estado;
        private String efecto;

        public string RfcEmisor { get => rfcEmisor; set => rfcEmisor = value; }
        public string RfcReceptor { get => rfcReceptor; set => rfcReceptor = value; }
        public DateTime? FechaDescarga { get => fechaDescarga; set => fechaDescarga = value; }
        public string Total { get => total; set => total = value; }
        public DateTime FechaEmision { get => fechaEmision; set => fechaEmision = value; }
        public string Pacquecertifico { get => pacquecertifico; set => pacquecertifico = value; }
        public DateTime? FechaCertificacion { get => fechaCertificacion; set => fechaCertificacion = value; }
        public bool DisponibleXML { get => disponibleXML; set => disponibleXML = value; }
        public bool DisponibleMETA { get => disponibleMETA; set => disponibleMETA = value; }
        public string SolicitadaMetodo { get => solicitadaMetodo; set => solicitadaMetodo = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Efecto { get => efecto; set => efecto = value; }
        public string Uuid { get => uuid; set => uuid = value; }

        /// <summary>
        /// Indica si el CFDI del que se tiene informacion se le descargo su XML.
        /// </summary>
        /// <returns></returns>
        public bool EsSolicitadoPorXML() {
            return solicitadaMetodo.Equals(SOLICITADO_POR.DESC) || solicitadaMetodo.Equals(SOLICITADO_POR.BOTH);
        }
        public bool EsSolicitadoPorMeta() {
            return solicitadaMetodo.Equals(SOLICITADO_POR.META);
        }

        static class SOLICITADO_POR {
            public static string DESC = "DESC";
            public static string META = "META";
            public static string BOTH = "BOTH";
        }
    }
}
