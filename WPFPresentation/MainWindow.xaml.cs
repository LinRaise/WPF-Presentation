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
            this.DataContext = this;
            SampleSelector.SelectedItem = Samples[0];
        }

        private void LoadSamples()
        {
            _samples.Add(new SampleViewModel
                {
                    Name = "Grid Sample",
                    Code = GetResourceText("WPFPresentation.Samples.GridSample.xaml")
                });
            _samples.Add(new SampleViewModel
            {
                Name = "Box Model",
                Code = GetResourceText("WPFPresentation.Samples.BoxModelSample.xaml")
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
                //INFO: we can use this do make it more dynamic
            }


        }
    }
}
