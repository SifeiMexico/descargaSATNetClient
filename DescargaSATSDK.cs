using DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws;
using DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request;
using DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Response;
using Newtonsoft.Json;
 
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK {
    /// <summary>
    ///   author Daniel J hernandez Francico  <daniel.hernandez.job@gmail.com>
    /// </summary>
    public class DescargaSATSDK
       
        {

        public static string URL_BASE_DEVELOPMENT = "http://localhost:8181";
        public static string URL_BASE_PRODUCTION = "https://descargasat.sifei.com.mx";

        public string BaseURL { get { return this.client.BaseURL; } set { this.client.BaseURL = value; } }

        public string Token { get { return  this.client.APIKey; } set { this.client.APIKey = value; } }

        public int Timeout { get { return this.client.Timeout; } set { this.client.Timeout = value; } }


        public Client client { get; set; }

        public DescargaSATSDK() {
            client = new Client();
            BaseURL = URL_BASE_DEVELOPMENT;
            Timeout = 150000;// hasta 150 segundos
        }

        public WsResponseMaster<CFDIModelAPI> ObtenerCFDIPorUUID(string uuid) {
            if (string.IsNullOrEmpty(uuid)) {
                throw new ArgumentException("UUID de CFDI no debe ser null o vacio");
            }
            return this.client.Get<WsResponseMaster<CFDIModelAPI>>("/api/v2/descargasatsifei/cfdi/query/"+uuid);

        }
        /*
        public string ConsultarCFDIDatos(ParametersCFDIQuery par) {
            var jsoN=JsonConvert.SerializeObject(par, Formatting.Indented);
            return this.client.Post("/api/v2/descargasatsifei/cfdi/query", jsoN);
        }
        */
        public  WsResponseMaster<DataResponseCFDIConsulta> ConsultarCFDIDatos(ParametersCFDIQuery par) {
            var jsoN = JsonConvert.SerializeObject(par, Formatting.Indented);
            var Responsebody =this.client.Post<WsResponseMaster<DataResponseCFDIConsulta>>("/api/v2/descargasatsifei/cfdi/query", jsoN);
            return Responsebody;
        }

        public WsResponseMaster<DataDescargaProgramadaDetail> ObtenerDetalleDescarga(string uuidDescarga) {
            if (string.IsNullOrEmpty(uuidDescarga)) {
                throw new ArgumentException("UUID de Descarga no debe ser null o vacio");
            }
            return this.client.Get<WsResponseMaster<DataDescargaProgramadaDetail>>("/api/v2/descargasatsifei/DescargaProgramada/" + uuidDescarga);
        }

        public WsResponseMaster<DataResponseDescargaProgramada> ProgramarDescarga(DescargaProgramadaRequest body) {
            var jsoN = JsonConvert.SerializeObject(body, Formatting.Indented);
            return this.client.Post<WsResponseMaster<DataResponseDescargaProgramada>>("/api/v2/descargasatsifei/DescargaProgramada", jsoN);
        }

        public WsResponseMaster<string> ReactivarDescarga(string uuid) {
            if (string.IsNullOrEmpty(uuid)) {
                throw new ArgumentException("UUID de Descargar no debe ser null o vacio");
            }
            return this.client.Post<WsResponseMaster<string>>("/api/v2/descargasatsifei/DescargaProgramada/" + uuid);
        }

        public WsResponseMaster<List<DataDescargaProgramada>> ConsultarLasDescargasDiarias(ParametersDescargasDiarias parameter) {
            return  this.client.Post<WsResponseMaster<List<DataDescargaProgramada>>>("/api/v2/descargasatsifei/DescargaProgramadas/query", parameter);
        }

        public WsResponseMaster<string> DescargarCFDIPorUUID(string uuid) {
            if (string.IsNullOrEmpty(uuid)) {
                throw new ArgumentException("UUID de CFDI no debe ser null o vacio");
            }
            return this.client.Get<WsResponseMaster<string>>("/api/v2/descargasatsifei/cfdi/download/" + uuid);
        }

        public WsResponseMaster<string> DescargarCFDIConsulta(ParametersDownloadCFDI parameters) {
            var json=JsonConvert.SerializeObject(parameters, Formatting.Indented);
            return this.client.Post<WsResponseMaster<string>>("/api/v2/descargasatsifei/cfdi/download",json);
        }
        public WsResponseMaster<bool> ExisteCFDI(string uuid) {
            if (string.IsNullOrEmpty(uuid)) {
                throw new ArgumentException("UUID de no CFDI debe ser null o vacio");
            }

            return this.client.Get<WsResponseMaster<bool>>("/api/v2/descargasatsifei/cfdi/exist/" + uuid);
        }
        public WsResponseMaster<DataEFirmaResponse> SubirEFirma(ParameterSubirEFirma para) {
            return this.client.Post<WsResponseMaster<DataEFirmaResponse>>("/api/v2/descargasatsifei/certificado",para);
        }
        public WsResponseMaster<int?> DesbloquarCFDI(ParameterDesbloquarItems para) {
            return this.client.Post<WsResponseMaster<int?>>("/api/v2/descargasatsifei/cfdi/DesbloquearCFDIAPI", para);
        }


        public WsResponseMaster<ResponseConsultarConfiguracion> ConsultarConfiguracion() {
            return this.client.Post<WsResponseMaster<ResponseConsultarConfiguracion>>("/api/v2/descargasatsifei/configuracion/query", new Object());
        }

        public WsResponseMaster<ResponseConsultarConfiguracion> EstablecerMetodoDescarga(ParametersEsteblecerConfiguracion para) {
            return this.client.Post<WsResponseMaster<ResponseConsultarConfiguracion>>("/api/v2/descargasatsifei/configuracion/metodoDescarga", para);
        }

        public WsResponseMaster<ResponseConsultarConfiguracion> EstablecerHorasEspera(ParametersEsteblecerConfiguracion para) {
            return this.client.Post<WsResponseMaster<ResponseConsultarConfiguracion>>("/api/v2/descargasatsifei/configuracion/horasEspera", para);
        }
    }
}
