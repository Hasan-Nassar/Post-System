using FirstTask.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Modules
{
    public class Post
    {
        public int PostId { get; set; }

        public string UserId { get; set; }

        public  ApplicationUser User { get; set; }
        public string PostDescription { get; set; }

        public int? PostParentId { get; set; }  

        public string Type { get; set; }
    


        public Post Postparent { get; set; }        

        public ICollection<LikeOnPost> Likes { get; set; }

        public ICollection<File> files { get; set; }


    }

}



