using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Modules
{
    public class User
    {
        [Key]
        public int UserId { get; set; }



        public string UserName { get; set; }

        [StringLength(255)]
        public string UserEmail { get; set; }

        public string Password { get; set; }

        //public virtual List<Post> Posts { get; set; }

        public virtual ICollection<File> Files { get; set; }



    }

}

