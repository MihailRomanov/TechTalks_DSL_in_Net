using Microsoft.VisualStudio.Text.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TeamsManifestExtension.NavigationMargin
{
	class NavigationMargin : IWpfTextViewMargin
	{
		StackPanel navigationPanel;
		private IWpfTextView textView;

		public NavigationMargin(IWpfTextView textView)
		{
			this.textView = textView;
			navigationPanel = new StackPanel() { Orientation = Orientation.Horizontal };

			var btnUp = new Button()
			{
				Content = new TextBlock() { Text = "Up" },
				Width = 60,
				Margin = new Thickness(5)
			};

			btnUp.Click += BtnUp_Click;

			var btnDown = new Button()
			{
				Content = new TextBlock() { Text = "Down" },
				Width = 60,
				Margin = new Thickness(5)
			};

			btnDown.Click += BtnDown_Click;

			navigationPanel.Children.Add(btnUp);
			navigationPanel.Children.Add(btnDown);
		}

		private void BtnDown_Click(object sender, RoutedEventArgs e)
		{
			var lineCount = textView.VisualSnapshot.LineCount;
			textView.ViewScroller.ScrollViewportVerticallyByLines(ScrollDirection.Down, lineCount);
		}

		private void BtnUp_Click(object sender, RoutedEventArgs e)
		{
			var lineCount = textView.VisualSnapshot.LineCount;
			textView.ViewScroller.ScrollViewportVerticallyByLines(ScrollDirection.Up, lineCount);
		}

		public FrameworkElement VisualElement => navigationPanel;

		public double MarginSize => 40;

		public bool Enabled => true;

		public void Dispose()
		{
		}

		public ITextViewMargin GetTextViewMargin(string marginName)
		{
			return null;
		}
	}
}
