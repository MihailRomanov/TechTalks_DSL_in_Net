using System;
using System.Collections.Generic;
using System.Linq;
using ExternalDSL.Generator;
using Irony.Ast;
using Irony.Parsing;

namespace ExternalDSL.Grammar
{
    public class DialogGrammar : Irony.Parsing.Grammar
    {
        public DialogGrammar()
        {
            var fieldType = new NonTerminal("Field type")
            {
                Rule = ToTerm("Int32") | "String" | "DateTime" | "Double",
                AstConfig = new AstNodeConfig
                {
                    NodeCreator = (context, node) =>
                    {
                        node.AstNode = Enum.Parse(typeof(FieldType), node.ChildNodes.First().Token.ValueString);
                    }
                }
            };

            var fieldName = TerminalFactory.CreateCSharpIdentifier("Field name");
            fieldName.Flags = TermFlags.NoAstNode;

            var dialogField = new NonTerminal("Dialog field")
            {
                Rule = fieldName
                    + ToTerm(":")
                    + fieldType
                    + ";",
                AstConfig = new AstNodeConfig
                {
                    NodeCreator = (context, node) =>
                    {
                        var name = node.ChildNodes.Find(pn => pn.Term.Name == "Field name").Token.ValueString;
                        var type = (FieldType)node.ChildNodes.Find(pn => pn.Term.Name == "Field type").AstNode;

                        node.AstNode = new DialogField
                        {
                            Name = name,
                            Type = type
                        };
                    }
                }
            };

            var dialogFieldList = new NonTerminal("Dialog field list");
            dialogFieldList.Rule = MakeStarRule(dialogFieldList, dialogField);
            dialogFieldList.AstConfig = new AstNodeConfig
            {
                NodeCreator = (context, node) =>
                {
                    var fields = node.ChildNodes.FindAll(pn => pn.Term.Name == "Dialog field");
                    node.AstNode = new List<DialogField>(fields.Select(f => f.AstNode).OfType<DialogField>());
                }
            };

            var dialogClassName = TerminalFactory.CreateCSharpIdentifier("Class name");
            dialogClassName.Flags = TermFlags.NoAstNode;
            var titleTerm = TerminalFactory.CreateCSharpString("Title");
            titleTerm.Flags = TermFlags.NoAstNode;
            var widthTerm = TerminalFactory.CreateCSharpNumber("Width");
            widthTerm.Flags = TermFlags.NoAstNode;
            var heightTerm = TerminalFactory.CreateCSharpNumber("Height");
            heightTerm.Flags = TermFlags.NoAstNode;

            var dialog = new NonTerminal("Dialog")
            {
                Rule = ToTerm("Dialog")
                    + dialogClassName
                    + "("
                    + widthTerm
                    + ","
                    + heightTerm
                    + ")"
                    + titleTerm
                    + ToTerm("{")
                    + dialogFieldList
                    + ToTerm("}"),
                AstConfig = new AstNodeConfig
                {
                    NodeCreator = (context, node) =>
                    {
                        var name = node.ChildNodes.Find(pn => pn.Term.Name == "Class name").Token.ValueString;
                        var title = node.ChildNodes.Find(pn => pn.Term.Name == "Title").Token.ValueString;
                        var fields = (List<DialogField>)node.ChildNodes
                            .Find(pn => pn.Term.Name == "Dialog field list").AstNode;
                        var width = Double.Parse(node.ChildNodes.Find(pn => pn.Term.Name == "Width").Token.ValueString);
                        var height = Double.Parse(node.ChildNodes.Find(pn => pn.Term.Name == "Height").Token.ValueString);

                        node.AstNode = new DialogModel
                        {
                            Name = name,
                            Title = title,
                            Width = width,
                            Height = height,
                            Fields = fields
                        };
                    }
                }
            };

            this.Root = dialog;
            this.LanguageFlags = LanguageFlags.CreateAst;
        }
    }
}
