using FirstTask.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Modules
{
    
    public class File
    {
        
            public int FileId { get; set; }
            [StringLength(255)]
            public string FileName { get; set; }
            [StringLength(100)]
            public string ContentType { get; set; }
            public  ApplicationUser ApplicationUser { get; set; }
            public string UserId { get; set; }
            public  Post Post { get; set; }
            public int? PostId { get; set; }
            public string Username { get; set; }

    }
}

