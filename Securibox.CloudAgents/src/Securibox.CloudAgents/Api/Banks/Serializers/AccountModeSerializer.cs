using Newtonsoft.Json;
using Securibox.CloudAgents.Api.Banks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Securibox.CloudAgents.Api.Banks.Serializers
{
    class AccountModeSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.Value.ToString().ToLowerInvariant())
            {
                case "disabled":
                    return AccountMode.Disabled;
                case "noautomaticsynch":
                    return AccountMode.NoAutomaticSynch;
                case "enabled":
                    return AccountMode.Enabled;
                default:
                    return AccountMode.Enabled;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is AccountMode)
            {
                AccountMode accountModeValue = (AccountMode)value;
                switch (accountModeValue)
                {
                    case AccountMode.Disabled:
                        writer.WriteValue("Disabled");
                        return;

                    case AccountMode.Enabled:
                        writer.WriteValue("Enabled");
                        return;

                    case AccountMode.NoAutomaticSynch:
                        writer.WriteValue("NoAutomaticSynch");
                        return;

                    default:
                        writer.WriteValue("Enabled");
                        return;
                }
            }
            writer.WriteValue("Enabled");
        }
    }
}
