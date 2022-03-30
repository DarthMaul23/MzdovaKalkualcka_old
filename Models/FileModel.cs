using System;
using System.IO;
using static System.Guid;

namespace TestAPI
{
    public class FileModel
    {
        public Guid FileId { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; } = "";
    }
}