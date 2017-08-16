namespace SoundWizard.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Enums;
    using Model;
    using NAudio.Wave;
    using Utility;
    using IO;
    using MahApps.Metro.Controls;
    using Interfaces;

    public class MainViewModel : IMainViewModel
    {
        public MainViewModel(MediaElement mediaElement, DataGrid mediaGrid)
        {
            this.Playlist = new ObservableCollection<Media>();
            this.MediaElement = mediaElement;
            this.MediaGrid = mediaGrid;
            this.LoadCommands();
            this.MediaElement.MediaEnded += new RoutedEventHandler(this.LoopMediaEnded);
        }

        public bool Repeat { get; set; }

        public ICommand ForwardCommand { get; set; }

        public ICommand StopCommand { get; set; }

        public ICommand PauseCommand { get; set; }

        public ICommand PlayCommand { get; set; }

        public ICommand OpenCommand { get; set; }

        public ICommand ExitCommand { get; set; }

        public ICommand RewindCommand { get; set; }

        public ICommand FullScreenCommand { get; set; }

        public ICommand ReversePositionCommand { get; set; }

        public ICommand ForwardPositionCommand { get; set; }

        public ICommand VolumeIncreaseCommand { get; set; }

        public ICommand VolumeDecreaseCommand { get; set; }

        public ICommand ExitFullScreenCommand { get; set; }

        public DataGrid MediaGrid { get; set; }

        public ObservableCollection<Media> Playlist { get; set; }

        public Media CurrentMedia { get; set; }
        
        public MediaElement MediaElement { get; set; }

        public void PlayMedia(object obj)
        {
            if (this.MediaElement.Source == null)
            {
                this.MediaElement.Source = new Uri(this.CurrentMedia.Path);
            }

            if (this.MediaElement.Source.LocalPath != this.CurrentMedia.Path)
            {
                this.MediaElement.Source = new Uri(this.CurrentMedia.Path);
                this.MediaElement.Play();
            }

            this.MediaElement.Play();
        }

        private void LoadCommands()
        {
            this.PlayCommand = new CustomCommand(this.PlayMedia, this.CanPlayMedia);
            this.PauseCommand = new CustomCommand(this.PauseMedia, this.CanPauseMedia);
            this.OpenCommand = new CustomCommand(this.LoadNewMedia, this.CanLoadNewMedia);
            this.ExitCommand = new CustomCommand(this.CloseApp, this.CanCloseApp);
            this.StopCommand = new CustomCommand(this.StopMedia, this.CanStopMedia);
            this.RewindCommand = new CustomCommand(this.RewindLoop, this.CanRewindLoop);
            this.ForwardCommand = new CustomCommand(this.ForwardLoop, this.CanForwardLoop);
            this.FullScreenCommand = new CustomCommand(this.FullScreen, this.CanFullScreen);
            this.ReversePositionCommand = new CustomCommand(this.ReversePosition, this.CanReversePosition);
            this.ForwardPositionCommand = new CustomCommand(this.ForwardPosition, this.CanForwardPosition);
            this.VolumeIncreaseCommand = new CustomCommand(this.VolumeIncrease, this.CanVolumeIncrease);
            this.VolumeDecreaseCommand = new CustomCommand(this.VolumeDecrease, this.CanVolumeDecrease);
            this.ExitFullScreenCommand = new CustomCommand(this.ExitFullScreen, this.CanExitFullScreen);
        }

        private bool CanExitFullScreen(object obj)
        {
            return true;
        }

        private void ExitFullScreen(object obj)
        {
            var currentWin = obj as Window;
            MediaElement.MaxWidth = 600;
            MediaElement.MaxHeight = 385;
            MediaElement.Width = 600;
            MediaElement.Height = 385;
            currentWin.Width = 1200;
            currentWin.Height = 700;
            currentWin.WindowState = WindowState.Normal;
            MediaElement.Margin = new Thickness(584, 279, -584, -279);
        }

        private bool CanVolumeDecrease(object obj)
        {
            return true;
        }

        private void VolumeDecrease(object obj)
        {
            var currentWin = obj as Slider;
            MediaElement.Volume -= 0.05;
            currentWin.Value -= 0.05;
        }

        private bool CanVolumeIncrease(object obj)
        {
            return true;
        }

        private void VolumeIncrease(object obj)
        {
            var currentWin = obj as Slider;
            MediaElement.Volume += 0.05;
            currentWin.Value += 0.05;
        }

        private bool CanForwardPosition(object obj)
        {
            return true;
        }

        private void ForwardPosition(object obj)
        {
            this.MediaElement.Position += TimeSpan.FromSeconds(2);
        }

        private bool CanReversePosition(object obj)
        {
            return true;
        }

        private void ReversePosition(object obj)
        {
            this.MediaElement.Position -= TimeSpan.FromSeconds(2);
        }

        private void PauseMedia(object obj)
        {
            this.MediaElement.Pause();
        }

        private bool CanPauseMedia(object obj)
        {
            return true;
        }

        private bool CanFullScreen(object obj)
        {
            return true;
        }

        private void FullScreen(object obj)
        {
            var currentWin = obj as MetroWindow;
            this.MediaElement.MaxWidth = SystemParameters.PrimaryScreenWidth;
            this.MediaElement.MaxHeight = SystemParameters.PrimaryScreenHeight;
            this.MediaElement.Width = SystemParameters.PrimaryScreenWidth;
            this.MediaElement.Height = SystemParameters.PrimaryScreenHeight;
            currentWin.Width = SystemParameters.PrimaryScreenWidth;
            currentWin.Height = SystemParameters.PrimaryScreenHeight;
            currentWin.WindowState = WindowState.Maximized;
            this.MediaElement.Margin = new Thickness(0, 0, 0, 0);
            if (this.MediaElement.HasVideo)
            {
                currentWin.IgnoreTaskbarOnMaximize = true;
            }
            else
            {
                currentWin.IgnoreTaskbarOnMaximize = false;
            }
        }

        private bool CanForwardLoop(object obj)
        {
            return (this.MediaGrid.SelectedIndex < this.Playlist.Count - 1 || this.Repeat) && this.Playlist.Count != 0;
        }

        private void ForwardLoop(object obj)
        {
            if (this.MediaGrid.SelectedIndex == this.Playlist.Count - 1 && this.Repeat)
            {
                this.MediaGrid.SelectedIndex = 0;
            }
            else
            {
                this.MediaGrid.SelectedIndex++;
            }
        }

        private bool CanRewindLoop(object obj)
        {
            return (this.MediaGrid.SelectedIndex != 0 || this.Repeat) && this.Playlist.Count > 0;
        }

        private void RewindLoop(object obj)
        {
            if (this.MediaGrid.SelectedIndex == 0 && this.Repeat)
            {
                this.MediaGrid.SelectedIndex = this.Playlist.Count - 1;
            }
            else
            {
                this.MediaGrid.SelectedIndex--;
            }
        }

        private bool CanStopMedia(object obj)
        {
            return true;
        }

        private void StopMedia(object obj)
        {
            this.MediaElement.Stop();
        }

        private bool CanCloseApp(object obj)
        {
            if (Application.Current != null)
            {
                return true;
            }

            return false;
        }

        private void CloseApp(object obj)
        {
            Application.Current.Shutdown();
        }

        private bool CanLoadNewMedia(object obj)
        {
            return true;
        }

        private void LoadNewMedia(object obj)
        {
            bool firstLoad = false;
            if (this.Playlist.Count == 0)
            {
                firstLoad = true;
            }

            CommandInterpreter commandInterpreter = new CommandInterpreter(Playlist);
            commandInterpreter.InterpretCommand(obj.ToString(), this.CurrentMedia);

            if (firstLoad && this.Playlist.Count > 0)
            {
                this.CurrentMedia = this.Playlist[0];
                this.MediaGrid.SelectedIndex = 0;
                this.MediaElement.Pause();
            }
        }

        private bool CanPlayMedia(object obj)
        {
            return this.Playlist.Count > 0;
        }

        private string AudioFormater()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("All Supported Audio | ");
            foreach (MediaFormats type in Enum.GetValues(typeof(MediaFormats)))
            {
                sb.Append($"*.{type}; ");
            }

            foreach (MediaFormats type in Enum.GetValues(typeof(MediaFormats)))
            {
                sb.Append($"|{type}s |*.{type}");
            }

            return sb.ToString().Trim();
        }

        private TimeSpan GetMediaDurationInSeconds(string filePath)
        {
            MediaFoundationReader audioReader = new MediaFoundationReader(filePath);

            return audioReader.TotalTime;
        }

        private void LoopMediaEnded(object sender, RoutedEventArgs e)
        {
            this.MediaElement.Stop();

            if (MediaGrid.SelectedIndex == this.MediaGrid.Items.Count - 1)
            {
                if (this.CanForwardLoop(sender))
                {
                    MediaGrid.SelectedIndex = 0;
                }
                else
                {
                    return;
                }
            }
            else
            {
                MediaGrid.SelectedIndex++;
            }

            this.MediaElement.Play();
        }
    }
}