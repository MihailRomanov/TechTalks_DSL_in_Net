using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Utilities;
using Microsoft.WebTools.Languages.Json.Editor.Completion;
using Microsoft.WebTools.Languages.Json.Parser.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace TeamsManifestExtension.Completion
{
	[Export(typeof(IJsonCompletionListProvider))]
	[Name("ManifestCompletionListProvider_VersionAndId")]
	internal class ManifestCompletionListProvider_VersionAndId : IJsonCompletionListProvider
	{
		[Import]
		SVsServiceProvider serviceProvider = null;

		public JsonCompletionContextType ContextType => JsonCompletionContextType.PropertyValue;

		public IEnumerable<JsonCompletionEntry> GetListEntries(JsonCompletionContext context)
		{
			var property = (MemberNode) context.ContextNode;
			var propertyName = property.Name.GetCanonicalizedText();
			var completionSession = (ICompletionSession)context.Session;

			var dte = (DTE2)serviceProvider.GetService(typeof(DTE));

			switch (propertyName)
			{
				case "version":
					return new JsonCompletionEntry[] {
						new JsonCompletionEntry("1.0", "\"1.0\"", "Version 1.0", null, "", false, completionSession)
					};

				case "id":
					return new JsonCompletionEntry[] {
						new JsonCompletionEntry("New id...", $"\"{Guid.NewGuid().ToString("D")}\"", "Generate new GUID",
						null, "", false, completionSession)
					};
			}

			return new JsonCompletionEntry[0];
		}

	}
}
