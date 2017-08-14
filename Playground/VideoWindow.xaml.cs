using System.Windows;
using System.Windows.Media;

namespace Playground
{
    /// <summary>
    /// Interaction logic for VideoWindow.xaml
    /// </summary>
    public partial class VideoWindow : Window
    {
        public VideoWindow(VisualBrush visualBrush)
        {
            InitializeComponent();
            display.Fill = visualBrush;
        }
    }
}