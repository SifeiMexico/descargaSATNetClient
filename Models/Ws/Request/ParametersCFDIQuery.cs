using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DHF.Sifei.DescargaSAT.Ws.SDK.Models.Ws.Request {
   public class ParametersCFDIQuery {
        private DateTime? fechaFinal;
        private DateTime? fechaInicial;
        private String rfcEmisor;
        private String rfcReceptor;
        private String uuidCFDI;
        private String efectoCFDI;
        private int limit;
        private int offset;

        [JsonProperty(PropertyName = "fechaFinal")]
        public DateTime? FechaFinal { get => fechaFinal; set => fechaFinal = value; }
        [JsonProperty(PropertyName = "fechaInicial")]
        public DateTime? FechaInicial { get => fechaInicial; set => fechaInicial = value; }
        [JsonProperty(PropertyName = "rfcEmisor")]
        public string RfcEmisor { get => rfcEmisor; set => rfcEmisor = value; }
        [JsonProperty(PropertyName = "rfcReceptor")]
        public string RfcReceptor { get => rfcReceptor; set => rfcReceptor = value; }
        [JsonProperty(PropertyName = "uuidCFDI")]
        public string UuidCFDI { get => uuidCFDI; set => uuidCFDI = value; }
        [JsonProperty(PropertyName = "efectoCFDI")]
        public string EfectoCFDI { get => efectoCFDI; set => efectoCFDI = value; }
        [JsonProperty(PropertyName = "limit")]
        public int Limit { get => limit; set => limit = value; }
        [JsonProperty(PropertyName = "offset")]
        public int Offset { get => offset; set => offset = value; }

    }

    class DateTimeConverter : DateTimeConverterBase {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (reader.Value == null) {
                return null;
            }
              return (DateTime)reader.Value;
            }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            DateTime dateTimeValue = (DateTime)value;
            if (dateTimeValue == DateTime.MinValue) {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(value);
        }
    }
}
