using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Modules
{
    public class LikeOnPost
    {
        [Key]
        public int PostLikeId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

        public string UserName { get; set; }

        public Post Post { get; set; }
    }
}

