using FirstTask.Dtos;
using FirstTask.Modules;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FirstTask
{
    public class PagingResultUserDto
    {


        public IEnumerable<UserDto> Result { set; get; }
        public int TotalCount { get; set; }


    }


      

}
