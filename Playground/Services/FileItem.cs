namespace Playground.Services
{
    using System.IO;
    using Interfaces;

    public class FileItem : IFileItem
    {
        public FileItem(string file)
        {
            this.FullName = file;
        }

        public string FullName { get; set; }

        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(this.FullName);
        }
    }
}