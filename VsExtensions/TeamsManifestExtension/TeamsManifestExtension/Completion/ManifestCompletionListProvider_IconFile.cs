using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Utilities;
using Microsoft.WebTools.Languages.Json.Editor.Completion;
using Microsoft.WebTools.Languages.Json.Parser.Nodes;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;

namespace TeamsManifestExtension.Completion
{
	[Export(typeof(IJsonCompletionListProvider))]
	[Name("ManifestCompletionListProvider_IconFile")]
	internal class ManifestCompletionListProvider_IconFile : IJsonCompletionListProvider
	{
		private readonly string[] iconExtension = { ".png", ".jpg", ".gif" };

		[Import]
		SVsServiceProvider serviceProvider = null;

		[Import]
		private IGlyphService glyphService = null;

		public JsonCompletionContextType ContextType => JsonCompletionContextType.PropertyValue;

		public IEnumerable<JsonCompletionEntry> GetListEntries(JsonCompletionContext context)
		{
			var property = (MemberNode)context.ContextNode;
			var propertyName = property.UnquotedNameText;
			var completionSession = (ICompletionSession)context.Session;

			var dte = (DTE2)serviceProvider.GetService(typeof(DTE));

			switch (propertyName)
			{
				case "color":
				case "outline":
					return GetIconFileCompletionList(dte, completionSession);
			}

			return new JsonCompletionEntry[0];
		}

		private IEnumerable<JsonCompletionEntry> GetIconFileCompletionList(DTE2 dte, ICompletionSession session)
		{
			var currentProject = dte.ActiveDocument.ProjectItem.ContainingProject;
			var rootProjectItems = currentProject.ProjectItems.OfType<ProjectItem>();

			var expandedProjectItemListNames = rootProjectItems.SelectMany(pi => GetProjectItemNamesWithFolderPath("", pi));
			var iconNames = expandedProjectItemListNames.Where(piName => iconExtension.Contains(Path.GetExtension(piName)));

			var glyph = glyphService.GetGlyph(StandardGlyphGroup.GlyphGroupField, StandardGlyphItem.GlyphItemPublic);

			return iconNames.Select(
					iconName => new JsonCompletionEntry(iconName, '"' + iconName + '"', "Icon", glyph, "", false, session)
				);

		}

		private IEnumerable<string> GetProjectItemNamesWithFolderPath(string folderPrefix, ProjectItem projectItem)
		{
			var itemFullName = string.IsNullOrEmpty(folderPrefix) ?
				projectItem.Name
				: folderPrefix + "/" + projectItem.Name;

			if (projectItem.ProjectItems.Count <= 0)
				return new string[] { itemFullName };

			var result = new List<string>();

			foreach (ProjectItem pi in projectItem.ProjectItems)
			{
				var childrenItems = GetProjectItemNamesWithFolderPath(itemFullName, pi);
				result.AddRange(childrenItems);
			}

			return result;
		}

	}
}
