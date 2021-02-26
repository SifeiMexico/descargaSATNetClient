using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws {
   public class WsResponseMaster<T> :WsResponse{
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
