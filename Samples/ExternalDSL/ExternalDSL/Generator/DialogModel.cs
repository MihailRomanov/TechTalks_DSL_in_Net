using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExternalDSL.Generator
{
    [XmlRoot(Namespace = "https://kontur.ru/schemas/xml_dsl_sample")]
    public class DialogModel
    {
        [XmlAttribute]
        public string Title { get; set; }
        [XmlAttribute]
        public double Height { get; set; }
        [XmlAttribute]
        public double Width { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        public List<DialogField> Fields { get; set; } = new List<DialogField>();
    }

    public class DialogField
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Label { get; set; }
        [XmlAttribute]
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType Type {get;set;}
    }

    public enum FieldType
    {
        Int32,
        String,
        DateTime,
        Double
    }

}