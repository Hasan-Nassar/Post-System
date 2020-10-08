using FirstTask.Core.Dtos.Post;
using FirstTask.Dtos;
using FirstTask.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Persistence.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {

        void RemovePost(int Id);

        void DeleteLike(int id);

        Task<Post> GetPost(int id);

        Task<PagingResultPostDto> GetAll(int? pageIndex, int? pageSize);

        Task<PagingResultPostDto> GetAllCommentByPostId(int? pageIndex, int? pageSize, int postId);


    }
}





