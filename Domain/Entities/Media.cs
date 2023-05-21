using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Media : BaseEntity
    {
        public string RealFilename { get; set; }
        public string EncodedFilename { get; set; }
        public string FilePath { get; set; }
        public string RootPath { get; set; }
        public string AbsolutePath { get; set; }
        public long Size { get; set; }
        public bool Deleted { get; set; }
    }
}
