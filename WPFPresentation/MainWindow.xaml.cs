using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;

namespace WPFPresentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<SampleViewModel> _samples = new List<SampleViewModel>();

        public MainWindow()
        {
            InitializeComponent();
            LoadSamples();
            DataContext = this;
            SampleSelector.SelectedItem = Samples[0];

            Loaded += MainWindow_Loaded;
        }

        private void LoadSamples()
        {
            _samples.Add(new SampleViewModel
            {
                Name = "Layout Overview",
                Code = GetResourceText("WPFPresentation.Samples.BoxModelSample.xaml")
            });

            _samples.Add(new SampleViewModel
            {
                Name = "Height & Width",
                Code = GetResourceText("WPFPresentation.Samples.SizeSample.xaml")
            });

            _samples.Add(new SampleViewModel
            {
                Name = "Margin & Padding",
                Code = GetResourceText("WPFPresentation.Samples.MarginPadding.xaml")
            });

            _samples.Add(new SampleViewModel
            {
                Name = "Visibility",
                Code = GetResourceText("WPFPresentation.Samples.VisibilitySample.xaml")
            });

            _samples.Add(new SampleViewModel
            {
                Name = "Alignments",
                Code = GetResourceText("WPFPresentation.Samples.AlignmentSample.xaml")
            });

            _samples.Add(new SampleViewModel
            {
                Name = "Transforms",
                Code = GetResourceText("WPFPresentation.Samples.TransformsSample.xaml")
            });

            _samples.Add(new SampleViewModel
            {
                Name = "Transforms 2.",
                Code = GetResourceText("WPFPresentation.Samples.Transforms2Sample.xaml")
            });
        }

        private string GetResourceText(string path)
        {
            Stream resourseStream = this.GetType().Assembly.GetManifestResourceStream(path);
            return new StreamReader(resourseStream).ReadToEnd();
        }

        public List<SampleViewModel> Samples
        {
            get { return _samples; }
            set { _samples = value; }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var samples = this.GetType().Assembly.GetManifestResourceNames().Where(n => n.Contains(".xaml"));

            foreach (var sample in samples)
            {
                //INFO: we can use this do make load the embedded resources in an automated fashion
            }
        }
    }
}
