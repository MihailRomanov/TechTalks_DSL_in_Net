using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using Microsoft.WebTools.Languages.Json.Editor.Document;
using Microsoft.WebTools.Languages.Json.Parser.Nodes;
using Microsoft.WebTools.Languages.Shared.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Windows.Media;

namespace TeamsManifestExtension.ColorMarker
{
	[Export(typeof(ITaggerProvider))]
	[TagType(typeof(ColorMarkerTag))]
	[ContentType("json")]
	internal class TaggerProvider : ITaggerProvider
	{
		public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
		{
			return new ColorMarkerTagger(buffer) as ITagger<T>;
		}
	}

	internal class ColorMarkerTagger : ITagger<ColorMarkerTag>
	{
		private ITextBuffer buffer;

		public ColorMarkerTagger(ITextBuffer buffer)
		{
			this.buffer = buffer;
		}

		public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

		public IEnumerable<ITagSpan<ColorMarkerTag>> GetTags(NormalizedSnapshotSpanCollection spans)
		{
			var jsonDocument = JsonEditorDocument.FromTextBuffer(buffer);
			var treeRoot = jsonDocument.DocumentNode;

			var result = new List<ITagSpan<ColorMarkerTag>>();

			var visitor = new NodeVisitor(
				(item) =>
				{
					var property = item as MemberNode;

					if (property != null)
					{
						string propertyName = property.Name.GetCanonicalizedText();
						if ((propertyName == "accentColor") && (property.Value != null))
						{
							var markerSpan = new SnapshotSpan(buffer.CurrentSnapshot, property.Value.Start, property.Value.Span.Length);
							Color? color = TextToColor(property.Value.GetText().Substring(1, property.Value.GetText().Length - 2));

							if (color.HasValue)
							{
								var tagSpan = new TagSpan<ColorMarkerTag>(markerSpan, new ColorMarkerTag(color.Value));

								result.Add(tagSpan);
							}

							return VisitNodeResult.SkipChildren;
						}
					}

					return VisitNodeResult.Continue;
				});

			treeRoot.Accept(visitor);

			return result;

		}

		private Color? TextToColor(string text)
		{
			if (text.Length != 7)
				return null;

			var rText = text.Substring(1, 2);
			var gText = text.Substring(3, 2);
			var bText = text.Substring(5, 2);

			return new Color()
			{
				A = 0xFF,
				R = byte.Parse(rText, NumberStyles.HexNumber, null),
				G = byte.Parse(gText, NumberStyles.HexNumber, null),
				B = byte.Parse(bText, NumberStyles.HexNumber, null),
			};
		}
	}
}
