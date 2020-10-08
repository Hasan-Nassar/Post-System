using FirstTask.Dtos;
using FirstTask.Modules;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<UserDto> Result { set; get; }
        
    }
}



