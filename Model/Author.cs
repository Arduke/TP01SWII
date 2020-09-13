using System;
using System.Collections.Generic;
using System.Text;

namespace EFGetStarted.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public char gender { get; set; }
        public string email { get; set; }
    }
}
