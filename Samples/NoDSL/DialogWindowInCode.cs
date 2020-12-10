using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace NoDSL
{
    public class DialogWindowInCode : Window
    {
        public DialogModel Model { get; set; }

        public DialogWindowInCode(DialogModel dialogModel)
        {
            Model = dialogModel;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Height = 200;
            Width = 300;
            Title = "Dialog Window (in code)";
            DataContext = Model;

            var docPanel = new DockPanel() { Margin = new Thickness(10), LastChildFill = true };
            Content = docPanel;

            var buttonPanel = new StackPanel()
            {
                Height = 20,
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            docPanel.Children.Add(buttonPanel);
            buttonPanel.SetValue(DockPanel.DockProperty, Dock.Bottom);

            var okButton = new Button() { Content = "OK", Width = 40, IsDefault = true,
                Margin = new Thickness(0, 0, 10, 0) };
            okButton.Click += (sender, args) => { DialogResult = true; };

            var cancelButton = new Button() { Content = "Cancel", Width = 40, IsCancel = true };
            cancelButton.Click += (sender, args) => { DialogResult = false; };

            buttonPanel.Children.Add(okButton);
            buttonPanel.Children.Add(cancelButton);

            var fieldsPannel = new Grid();
            fieldsPannel.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            fieldsPannel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            fieldsPannel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            fieldsPannel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            docPanel.Children.Add(fieldsPannel);
            fieldsPannel.SetValue(DockPanel.DockProperty, Dock.Top);

            var label1 = new Label { Content = "Field 1:", VerticalAlignment = VerticalAlignment.Center };
            fieldsPannel.Children.Add(label1);
            label1.SetValue(Grid.ColumnProperty, 0);
            label1.SetValue(Grid.RowProperty, 0);

            var label2 = new Label { Content = "Field 2:", VerticalAlignment = VerticalAlignment.Center };
            fieldsPannel.Children.Add(label2);
            label2.SetValue(Grid.ColumnProperty, 0);
            label2.SetValue(Grid.RowProperty, 1);

            var textBox1 = new TextBox { VerticalAlignment = VerticalAlignment.Center };
            textBox1.SetValue(Grid.ColumnProperty, 1);
            textBox1.SetValue(Grid.RowProperty, 0);
            textBox1.SetBinding(TextBox.TextProperty, new Binding(nameof(Model.Field1)) { Mode = BindingMode.TwoWay });
            fieldsPannel.Children.Add(textBox1);


            var textBox2 = new TextBox { VerticalAlignment = VerticalAlignment.Center };
            textBox2.SetValue(Grid.ColumnProperty, 1);
            textBox2.SetValue(Grid.RowProperty, 1);
            textBox2.SetBinding(TextBox.TextProperty, new Binding(nameof(Model.Field2)) { Mode = BindingMode.TwoWay });
            fieldsPannel.Children.Add(textBox2);
        }
    }
}
