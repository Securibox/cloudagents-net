using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Securibox.CloudAgents.Api.Banks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Api.Banks.Serializers
{
    class CurrencySerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.Value)
            {
                case "euro":
                    return Currency.EUR;

                case "usd":
                    return Currency.USD;

                default:
                    return Currency.EUR;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if(value is Currency)
            {
                Currency currencyValue = (Currency)value;
                switch (currencyValue)
                {
                    case Currency.EUR:
                        writer.WriteValue("Euro");
                        return;

                    case Currency.USD:
                        writer.WriteValue("Usd");
                        return;

                    default:
                        writer.WriteValue("Euro");
                        return;
                }
            }
            writer.WriteValue("Euro");
        }
    }
}
