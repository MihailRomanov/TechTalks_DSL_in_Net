using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsManifestExtension.NavigationMargin
{
	[Export(typeof(IWpfTextViewMarginProvider))]
	[ContentType("json")]
	[TextViewRole(PredefinedTextViewRoles.Document)]
	[MarginContainer(PredefinedMarginNames.Top)]
	[Name("NavigationMarginProvider")]
	class NavigationMarginProvider : IWpfTextViewMarginProvider
	{
		public IWpfTextViewMargin CreateMargin(IWpfTextViewHost wpfTextViewHost, IWpfTextViewMargin marginContainer)
		{
			return new NavigationMargin(wpfTextViewHost.TextView);
		}
	}
}
