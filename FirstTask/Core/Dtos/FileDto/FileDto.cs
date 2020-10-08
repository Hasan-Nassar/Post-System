using FirstTask.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Dtos
{
    public class FileDto
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public int? Userid { get; set; }
        public string Username { get; set; }
        public int? PostId { get; set; }
        public Post Post { get; set; }

    }
}