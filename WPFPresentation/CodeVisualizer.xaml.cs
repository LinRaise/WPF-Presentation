using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace WPFPresentation
{
    /// <summary>
    /// Interaction logic for CodeVisualizer.xaml
    /// </summary>
    public partial class CodeVisualizer : UserControl
    {
        public CodeVisualizer()
        {
            InitializeComponent();
            DataContextChanged += CodeVisualizer_DataContextChanged;
            flipper.SpinAxis = Orientation.Vertical;
            flipper.SpinTime = 0.5;
        }

        void CodeVisualizer_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue != DependencyProperty.UnsetValue)
            {
                SampleViewModel sample = e.NewValue as SampleViewModel;
                textEditor.Text = sample.Code;
                UIElement control = (UIElement)XamlReader.Parse(sample.Code);
                WPFDemoContainer.Children.Clear();
                WPFDemoContainer.Children.Add(control);
            }
        }

        private void EvalButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newXaml = textEditor.Text;
            UIElement newContent;
            try
            {
                newContent = (UIElement)XamlReader.Parse(newXaml);
                evalButton.Background = new SolidColorBrush(Colors.Green);
            }
            catch (Exception ex)
            {
                ToolTip t = new ToolTip();
                t.Content = ex.ToString();
                evalButton.Background = new SolidColorBrush(Colors.Red);
                evalButton.ToolTip = t;
                return;
            }
            evalButton.ToolTip = null;
            WPFDemoContainer.Children.Clear();
            WPFDemoContainer.Children.Add(newContent);
            flipper.FrontVisible = !flipper.FrontVisible;
        }

        private void FrontSwitchButton_OnClick(object sender, RoutedEventArgs e)
        {
            flipper.FrontVisible = !flipper.FrontVisible;
        }
    }
}
