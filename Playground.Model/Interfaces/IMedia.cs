namespace Playground.Model.Interfaces
{
    using System;

    public interface IMedia
    {
        string Title { get; }

        TimeSpan Duration { get; }

        string Path { get; }
    }
}