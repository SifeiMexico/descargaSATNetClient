using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Response {
    public class DataResponseDescargaProgramada {
        private String resultado;

        private String[] errores;

        private String[] exitosos;

        private String[] repetidos;

        private int diasyaprogramados;



        private int diasTotalesDeDescarga;

        private int totalDiasNuevosProgramados;

        private String tipoDescargaName;

        public string Resultado { get => resultado; set => resultado = value; }
        public string[] Errores { get => errores; set => errores = value; }
        public string[] Exitosos { get => exitosos; set => exitosos = value; }
        public string[] Repetidos { get => repetidos; set => repetidos = value; }
        public int Diasyaprogramados { get => diasyaprogramados; set => diasyaprogramados = value; }
        public int DiasTotalesDeDescarga { get => diasTotalesDeDescarga; set => diasTotalesDeDescarga = value; }
        public int TotalDiasNuevosProgramados { get => totalDiasNuevosProgramados; set => totalDiasNuevosProgramados = value; }
        public string TipoDescargaName { get => tipoDescargaName; set => tipoDescargaName = value; }
    }
}
