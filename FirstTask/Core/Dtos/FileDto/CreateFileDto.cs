using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Core.Dtos.FileDto
{
    public class CreateFileDto
    {
        public string UserId { get; set; }
        public int Postid { get; set; }
        public IFormFile File { get; set; }
    }
}

