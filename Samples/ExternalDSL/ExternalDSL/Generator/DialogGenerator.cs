using ExternalDSL.Generator;

public partial class DialogGenerator
{
    public DialogGenerator(DialogModel model, string @namespace)
    {
        _ModelField = model;
        _NamespaceField = @namespace;
    }
}
