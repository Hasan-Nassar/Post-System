using FirstTask.Modules;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Dtos
{
    public class PostDtos
    {

        public int PostId { get; set; }

        public string UserId { get; set; }


        public string PostDescription { get; set; }

        public int NumberOfLike { get; set; }
        public int NumberOfComment { get; set; }

        //public string Type { get; set; }

        //public virtual User User { get; set; }

        //public PostDtos Postparent { get; set; }

        public string Username { get; set; }

        public virtual IEnumerable<FileDto> Files { get; set; }


        //public ICollection<PostDtos> posts { get; set; }

    }
}

