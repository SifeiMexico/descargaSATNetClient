using DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Response {
    public class DataDescargaProgramada {
        private String uuid;
        private DateTime fechaInicial;

        private DateTime fechaFinal;
        /// <summary>
        /// Estado de la descarga: ESPERANDO,COMPLETADA
        /// </summary>
        private String estado;

        private int tipoDescarga;

        public string Uuid { get => uuid; set => uuid = value; }
        public DateTime FechaInicial { get => fechaInicial; set => fechaInicial = value; }
        public DateTime FechaFinal { get => fechaFinal; set => fechaFinal = value; }
        public string Estado { get => estado; set => estado = value; }


        public int TipoDescarga { get => tipoDescarga; set => tipoDescarga = value; }

        

        public bool isEstadoEsperando() {
            return this.estado.Equals(ESTADO.ESPERANDO);
        }
        public bool isEstadoEnProceso() {
            return this.estado.Equals(ESTADO.EN_PROCESO);
        }
        public bool isEstadoCompletado() {
            return this.estado.Equals(ESTADO.COMPLETADO);
        }
        public bool isEstadoERROR() {
            return this.estado.Equals(ESTADO.ERROR);
        }
        public bool isEstadoIncompleto() {
            return this.estado.Equals(ESTADO.INCOMPLETO);
        }
        public bool isEstadoBloqueado() {
            return this.estado.Equals(ESTADO.BLOQUEADO);
        }
    }
}
