using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK {
    /// <summary>
    ///  Author:Daniel J Hdz Fco<>, this class was created because of compatbibility problems,
    ///  there are many libraries for consuming API's Rest but all of them requires at least .net 4.5 or superior. For that I've created this class.
    ///  HttpClient is for nbe
    /// </summary>
    public class BaseClient {
       // public string APIKey { get; set; }

        public string APIURL { get; set; }

        public string METHOD { get; set; }

        public string Body { get; set; }
        public const string POST = "POST";
        public const string GET = "GET";
        public string ContentType { get; set; }
        public const string CONTENT_TYPE_JSON= "application/json;charset=utf-8";
        public const string CONTENT_TYPE_FORM_URL_ENCONDED = "application/x-www-form-urlencoded";

        public int Timeout { get; set; }

        public BaseClient() {
            Headers = new Dictionary<string, string>();
            ContentType = CONTENT_TYPE_JSON;
        }
        public Dictionary<string,string> Headers { get; set; }
        public void AddHeader(string key, string value) {
            Headers.Add(key,value);
        }
        public void SetAuthorizationHeader(string value) {
            Headers.Add("Authorization", value);
        }


        public string consume() {

            ServicePointManager.Expect100Continue = false;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(APIURL);
            httpWebRequest.Method = METHOD;
            if (this.Timeout != 0) {
                //https://docs.microsoft.com/en-us/dotnet/api/system.net.httpwebrequest.timeout?view=netframework-4.8
                //el tiempo por defecto es de 100,000 milisegundos, es decir 100 segundos
                httpWebRequest.Timeout = this.Timeout;
            }
            // AutomaticDecompression
            foreach (var header in Headers) {
                httpWebRequest.Headers.Add(header.Key   , header.Value);
            }
            //httpWebRequest.Headers.Add("Authorization", APIKey);
            if (null != Body) {
                httpWebRequest.ContentType = ContentType;

                byte[] bytes = new ASCIIEncoding().GetBytes(Body);
                httpWebRequest.ContentLength = (long)bytes.Length;
                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }


            WebResponse response = httpWebRequest.GetResponse(); //realiza la petiicon
            
            string statusDescription = ((HttpWebResponse)response).StatusDescription;
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string end = streamReader.ReadToEnd();
            streamReader.Close();
            return end;
        }
        public static string getFormURLEncoded(Dictionary<string, string> values) {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var item in values) {
                sb.AppendFormat("{0}={1}", Uri.EscapeDataString(item.Key), Uri.EscapeDataString(item.Value));

                if (i < values.Count - 1) {
                    sb.Append("&");
                }
                i++;
            }
            return sb.ToString();
        }



    }
}
