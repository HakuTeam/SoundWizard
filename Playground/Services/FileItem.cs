using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Services
{
    public class FileItem
    {
        public string FullName { get; set; }
        public FileItem(string file)
        {
            FullName = file;
        }

        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(FullName);
        }
    }
}
