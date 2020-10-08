using FirstTask.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FirstTask.Dtos
{
    public class UserDto
    {
        [Key]
        public string Id { get; set; }


        public string UserName { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}



