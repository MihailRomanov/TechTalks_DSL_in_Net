using ExternalDSL.Generator;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ExternalDSL
{
    public class XmlGeneratorTask : BaseGeneratorTask
    {
        public override DialogModel ReadModel(string modelContent)
        {
            var serializer = new XmlSerializer(typeof(DialogModel));
            return (DialogModel)serializer.Deserialize(XmlReader.Create(new StringReader(modelContent)));
        }
    }
}
