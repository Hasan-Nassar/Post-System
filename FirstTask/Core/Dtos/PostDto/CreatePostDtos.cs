using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Core.Dtos.Post
{
    public class CreatePostDtos
    {


        public string PostDescription { get; set; }


        public int? PostParentId { get; set; }


        public string UserId { get; set; }

    }
}


