using ExternalDSL.Generator;
using Irony.Parsing;

namespace ExternalDSL
{
    public class GrammarGeneratorTask : BaseGeneratorTask
    {
        public override DialogModel ReadModel(string modelContent)
        {
            var grammar = new Grammar.DialogGrammar();
            var parser = new Parser(grammar);

            var parsedTree = parser.Parse(modelContent);
            return (DialogModel)parsedTree.Root.AstNode;
        }
    }
}
