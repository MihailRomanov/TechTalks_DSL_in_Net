using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using Microsoft.WebTools.Languages.Json.Editor.Document;
using Microsoft.WebTools.Languages.Json.Parser.Nodes;
using Microsoft.WebTools.Languages.Shared.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace TeamsManifestExtension.MarkText
{
    [Export(typeof(ITaggerProvider))]
	[TagType(typeof(IconFileNameMarkerTag))]
	[ContentType("json")]
	class IconFileNameTaggerProvider : ITaggerProvider
	{
		public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
		{
			return new IconFileNameTagger(buffer) as ITagger<T>;
		}
	}

	class IconFileNameTagger : ITagger<IconFileNameMarkerTag>
	{
		private ITextBuffer buffer;

		public IconFileNameTagger(ITextBuffer buffer)
		{
			this.buffer = buffer;
		}

		public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

		public IEnumerable<ITagSpan<IconFileNameMarkerTag>> GetTags(NormalizedSnapshotSpanCollection spans)
		{
			var jsonDocument = JsonEditorDocument.FromTextBuffer(buffer);
			var treeRoot = jsonDocument.DocumentNode;

			var result = new List<ITagSpan<IconFileNameMarkerTag>>();

			var visitor = new NodeVisitor(
				(item) =>
				{
					var property = item as MemberNode;

					if (property != null)
					{
						string propertyName = property.Name.GetCanonicalizedText();
						if ((propertyName == "color" || propertyName == "outline") && (property.Value != null))
						{
							var markerSpan = new SnapshotSpan(buffer.CurrentSnapshot, property.Value.Start, property.Value.Span.Length);
							var tagSpan = new TagSpan<IconFileNameMarkerTag>(markerSpan, new IconFileNameMarkerTag());

							result.Add(tagSpan);

							return VisitNodeResult.SkipChildren;
						}
					}

					return VisitNodeResult.Continue;
				});

			treeRoot.Accept(visitor);

			return result;
		}
	}
}
