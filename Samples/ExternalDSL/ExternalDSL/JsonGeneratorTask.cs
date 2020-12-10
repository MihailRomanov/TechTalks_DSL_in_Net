using ExternalDSL.Generator;
using Newtonsoft.Json;

namespace ExternalDSL
{
    public class JsonGeneratorTask : BaseGeneratorTask
    {
        public override DialogModel ReadModel(string modelContent)
        {
            return JsonConvert.DeserializeObject<DialogModel>(modelContent);
        }
    }
}
