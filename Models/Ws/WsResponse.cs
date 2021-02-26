using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws {
   public class WsResponse {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }

        public Boolean IsStatusSuccess() {
            return this.Status == estatus.success;
        }
        public Boolean IsStatusFail() {
            return this.Status == estatus.fail;
        }
        public Boolean IsStatusError() {
            return this.Status == estatus.error;
        }

        static class estatus {
            public const string success = "success";
            public const string fail = "fail";
            public const string error = "error";
        }
        static class ERROR_CODES {
            public const string NOT_FOUND = "404";
            /// <summary>
            /// En caso de que no se disponga del XML a pesar de haber solicitado explicitamente la descarga de su XML.
            /// (Campo solicitadaPor DESC o BOTH) , esto sucede cuando se trata de un XML Recido CANCELADO.
            /// Ya que no es posible descargar ese XML, solo obtener su informacion.
            /// 
            /// En casos que sea diferente a cancelado recibido, significara que no pudo descargarse el XML, deberas de programar una descarga, o verificar si existen descargas con estado "INCOMPLETA".
            /// </summary>
            public const string CFDI_WITHOUT_XML = "2202";
            /// <summary>
            /// Este codigo se devuelve cuando no se puede descargar el XML, 
            /// la unica razon posible es que solo tenga resguardado los metados(ver campo solicitada_por), por lo que 
            /// no se tiene el XML en ACI DescargaSAT. Deberas solicitar una descarga de XML que contenga este XML.
            /// </summary>
            public const string CFDI_NOT_DOWNLOADABLE = "2203";      
            /// <summary>
            /// Cuando un CFDI no ha sido descontado de paquete cuando se descargo a ACI Reguardo, adquiere este estado.
            /// Debeas de conseguir un paquete nuevo y desbloquar el CFDI para poder descargalo.
            /// </summary>
            public const string CFDI_BLOQUEADO = "2205";
            

        }

        public bool isNotFound() {
            return Code == ERROR_CODES.NOT_FOUND;
        }


    }


}
