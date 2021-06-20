using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment2.Models
{
    public class TwitterPost
    {
        public string tweet { get; set; }

        public dynamic file { get; set; }

    }
}
