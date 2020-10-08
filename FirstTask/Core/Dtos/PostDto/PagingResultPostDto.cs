using FirstTask.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Core.Dtos.Post
{
    public class PagingResultPostDto
    {
        public IEnumerable<PostDtos> Result { set; get; }
        
        public int TotalCount { get; set; }
    }
}
