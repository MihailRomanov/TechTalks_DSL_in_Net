using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;
using System.Windows.Media;

namespace TeamsManifestExtension.MarkText
{
    [Export(typeof(EditorFormatDefinition))]
	[Name(IconFileNameDefinition)]
	[UserVisible(true)]
	class IconFileNameFormatDefinition : MarkerFormatDefinition
	{
		internal const string IconFileNameDefinition = "IconFileNameFormatDefinition";

		protected IconFileNameFormatDefinition()
		{
			this.BackgroundColor = Colors.Bisque;
			this.ForegroundColor = Colors.Black;
			this.ZOrder = 5;

			this.DisplayName = "_Teams Icon file name";
		}
	}

	class IconFileNameMarkerTag : TextMarkerTag
	{
		public IconFileNameMarkerTag()
			: base(IconFileNameFormatDefinition.IconFileNameDefinition)
		{
		}
	}
}
