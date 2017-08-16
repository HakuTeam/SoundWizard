namespace SoundWizard
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow
    {
        public ErrorWindow()
        {
            this.InitializeComponent();
        }

        private void CloseOnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}