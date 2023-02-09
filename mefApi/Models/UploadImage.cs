using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mefApi.Models
{
    public class UploadImage
    {
        public string? Image { get; set; }
        public string? Type { get; set; }
        public int MembreId { get; set; }
    }
}