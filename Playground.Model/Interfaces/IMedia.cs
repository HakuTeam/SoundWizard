using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Model.Interfaces
{
    public interface IMedia : IMediaMetaData
    {
        string Title { get; }

        TimeSpan Duration { get; }

        string Path { get; }
    }
}
