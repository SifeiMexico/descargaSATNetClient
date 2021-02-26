using DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws;
using Newtonsoft.Json;
 
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK {
    public class Client {
        public string  BaseURL { get; set; }

        public string  APIKey { get; set; }


        public BaseClient BaseClient { get; set; }

        public int Timeout { get; set; }


        public BaseClient BuildClient(String relativeUrl,string method,string body=null) {
            BaseClient = new BaseClient();
            BaseClient.APIURL = BaseURL + relativeUrl;
            BaseClient.METHOD = method;
            BaseClient.Timeout = Timeout;


            if (string.IsNullOrEmpty(APIKey)) {
                throw new Exception("Debes establecer un token");
            }
            BaseClient.SetAuthorizationHeader( APIKey);
            BaseClient.Body = body;
            return BaseClient;
        }


        public string Get(string relativeUrl) {
            BuildClient(relativeUrl, BaseClient.GET);
            var result = BaseClient.consume();             
            return result;


        }
        public string Post(string relativeUrl,string body) {
            BuildClient(relativeUrl, BaseClient.POST, body);
            var result= BaseClient.consume();
            WsResponse genericResponse =

             JsonConvert.DeserializeObject<WsResponse>(result);
            return result;
        }
        public T Post<T>(string relativeUrl, string body="") {
            BuildClient(relativeUrl, BaseClient.POST, body);
            var result = BaseClient.consume();
            T genericResponse = JsonConvert.DeserializeObject<T>(result);
            return genericResponse;           
        }
        public T Post<T>(string relativeUrl, Object body) {
            var jsoN = JsonConvert.SerializeObject(body, Formatting.Indented);
            BuildClient(relativeUrl, BaseClient.POST, jsoN);
            var result = BaseClient.consume();
            T genericResponse = JsonConvert.DeserializeObject<T>(result);
            return genericResponse;
        }
        public T Get<T>(string relativeUrl) {
            BuildClient(relativeUrl, BaseClient.GET);
            var result = BaseClient.consume();
            T genericResponse =JsonConvert.DeserializeObject<T>(result);           
            return genericResponse;
        }
    }
}
