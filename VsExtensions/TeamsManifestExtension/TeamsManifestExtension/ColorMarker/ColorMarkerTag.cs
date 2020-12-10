using Microsoft.VisualStudio.Text.Tagging;
using System.Windows.Media;

namespace TeamsManifestExtension.ColorMarker
{
	class ColorMarkerTag : SpaceNegotiatingAdornmentTag
	{
		public Color Color;

		public ColorMarkerTag(Color color)
			:base(20, 0, 0, 0, 0, Microsoft.VisualStudio.Text.PositionAffinity.Predecessor, color, "color")
		{
			this.Color = color;
		}
	}

}
