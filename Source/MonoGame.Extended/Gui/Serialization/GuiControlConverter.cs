using System;
using MonoGame.Extended.Gui.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonoGame.Extended.Gui.Serialization
{
    public class GuiControlConverter : JsonConverter
    {
        //private readonly GuiStyleSheet _styleSheet;

        //public GuiControlConverter(GuiStyleSheet styleSheet)
        //{
        //    _styleSheet = styleSheet;
        //}

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //if (objectType == typeof(GuiStyle))
            //    return _styleSheet.Styles[(string) reader.Value];

            var jObject = JObject.Load(reader);
            var type = (string)jObject.Property("Type");

            switch (type)
            {
                case "Button":
                    return jObject.ToObject<GuiButton>(serializer);
                default:
                    throw new InvalidOperationException($"Unexpected type {type}");
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GuiControl);// || objectType == typeof(GuiStyle);
        }
    }
}