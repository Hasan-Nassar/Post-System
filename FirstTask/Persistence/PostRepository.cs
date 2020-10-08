using AutoMapper;
using FirstTask.Core;
using FirstTask.Core.Dtos.Post;
using FirstTask.Dtos;
using FirstTask.Modules;
using FirstTask.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FirstTask.Persistence
{
    public class PostRepository: BaseRepository<Post> , IPostRepository
    {
        private readonly PostDbContext context;
        private readonly IMapper mapper;
        public PostRepository(PostDbContext context, IMapper mapper) :base(context)
        {
            this.context = context;
            this.mapper = mapper;
        }


        

        public void DeleteLike(int id)
        {
            var like = context.LikeOnPost.Find(id);
             context.LikeOnPost.Remove(like);
        }

        public void RemovePost(int Id) 
        {
            var post = context.Posts.Find(Id);
            if (post == null)
                throw new Exception("Post Not Found! ");

            var Posts = context.Posts.Where(p => p.PostParentId == Id).ToList();
            var FilesInComment = context.Files.Where(p => p.PostId == Id).ToList();

            if(FilesInComment.Count > 0)
            {
                context.Files.RemoveRange(FilesInComment);
            }
            foreach(var Post in Posts)
            {
                RemovePost(Post.PostId);
                var files = context.Files.Where(fi => fi.PostId == Id).ToList();
                if(files.Count > 0)
                {
                    context.Files.RemoveRange(files);
                }
                context.Posts.Remove(Post);
            }
            context.Posts.Remove(post);
            //context.Posts.Include(a => a.Postparent).Include(a => a.PostId == Id).Include(a=>a.PostParentId).ThenInclude(a => a.files);
            //context.Posts.RemovePost(Id);
        }


        public async Task<Post> GetPost(int postId)
        {
            var post = await context.Posts
               .SingleOrDefaultAsync(u => u.PostId == postId);
            return post;

        }

        public async Task<PagingResultPostDto> GetAll(int? pageIndex, int? pageSize)
        {
            
                PagingResultPostDto result = new PagingResultPostDto();
            
                if (pageIndex <= 0) pageIndex = 1;
                if (pageSize <= 0) pageIndex = 10;


                result.TotalCount = await context.Posts.CountAsync(p => p.PostParentId == null);

            var query = context.Posts.Where(p => p.PostParentId == null).Include(w => w.User).Include(w => w.files).Select(w =>
                new PostDtos
                {
                    NumberOfLike = context.LikeOnPost.Count(i => i.PostId == w.PostId),
                    NumberOfComment = context.Posts.Count(i => i.PostParentId == w.PostId),
                    PostId = w.PostId,
                    PostDescription = w.PostDescription,
                    Username = w.User.UserName,
                    UserId = w.UserId,
                    Files = mapper.Map<IEnumerable<File>, IEnumerable<FileDto>>(w.files)

                }).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
                result.Result = await query.ToListAsync();
                return result;

        }

        public async Task<PagingResultPostDto> GetAllCommentByPostId(int? pageIndex, int? pageSize, int postId)
        {

            PagingResultPostDto result = new PagingResultPostDto();

            if (pageIndex <= 0) pageIndex = 1;
            if (pageSize <= 0) pageIndex = 10;



            result.TotalCount = await context.Posts.CountAsync(p => p.PostParentId != null);

            var query = context.Posts.Where(p => p.PostParentId == postId).Include(w=>w.User).Include(w=>w.files)
            .Select(w =>
            new PostDtos
            {
                NumberOfLike = context.LikeOnPost.Count(i => i.PostId == w.PostId),
                NumberOfComment = context.Posts.Count(i => i.PostParentId == w.PostId),
                Username = w.User.UserName,
                PostId = w.PostId,
                PostDescription = w.PostDescription,
                UserId = w.UserId,
                Files = mapper.Map<IEnumerable<File>, IEnumerable<FileDto>>(w.files)

              
            }).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            result.Result =await query.ToListAsync();
            return result;

        }
    }
}




