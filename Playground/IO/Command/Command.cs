﻿namespace Playground.IO.Command
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Interfaces;
    using Model;

    public abstract class Command : IExecutable
    {
        protected Command(MediaElement mediaElement, ObservableCollection<Song> playList)
        {
            this.MediaElement = mediaElement;
            this.PlayList = playList;
        }

        protected Command(MediaElement mediaElement, ObservableCollection<Song> playList, ListBox listBoxView)
        {
            this.MediaElement = mediaElement;
            this.PlayList = playList;
            this.ListBoxView = listBoxView;
        }

        public ObservableCollection<Song> PlayList { get; set; }

        public MediaElement MediaElement { get; set; }

        public ListBox ListBoxView { get; set; }

        public abstract void Execute();
    }
}