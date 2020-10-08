using AutoMapper;
using FirstTask.Core;
using FirstTask.Core.Dtos.FileDto;
using FirstTask.Core.Dtos.Post;
using FirstTask.Dtos;
using FirstTask.Modules;
using FirstTask.Persistence;
using FirstTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Services
{
    public class PostService : IPostService

    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly PostDbContext _context;

        public PostService(IUnitOfWork unitOfWork ,IMapper mapper, PostDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<PostDtos> Addpost([FromBody] CreatePostDtos postDto)
        {
            var post = _mapper.Map<CreatePostDtos, Post>(postDto);

            if (postDto.PostParentId != null)
                post.Type = "comment";
            else post.Type = "post";

            var user = await _unitOfWork.UserRepository.GetUser(postDto.UserId);


            if (user == null)
                throw new Exception("User not found");

                _unitOfWork.PostRepository.Add(post);
                await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<Post, PostDtos>(post);
                result.Username = user.UserName;
                return result;
        }

        public async Task<string> DeletePost(int PostId)
        {
            _unitOfWork.PostRepository.RemovePost(PostId);
            await _unitOfWork.CompleteAsync();
            return "accept deleted";

        }

        

        public async Task<PostDtos> GetPost(int PostId)
        {
            var post = await _unitOfWork.PostRepository.GetPost(PostId);

            var user = await _unitOfWork.UserRepository.GetUser(post.UserId);

            var p = _mapper.Map<Post, PostDtos>(post);
            p.Username = user.UserName;

            return p;
        }

        public async Task<PagingResultPostDto> GetAll([FromQuery] int? pageIndex, [FromQuery] int? pageSize)
        {
            
                var Post = await _unitOfWork.PostRepository.GetAll(pageIndex, pageSize);
                return Post;
          
        }

        public async Task<PagingResultPostDto> GetAllComment([FromQuery] int? pageIndex, [FromQuery] int? pageSize,int postId)
        {

            var Post = await _unitOfWork.PostRepository.GetAllCommentByPostId(pageIndex , pageSize , postId);
            return Post;

        }


        public async Task<PostDtos> UpdatePost(int id, [FromBody] PostDtos postDtos)
        {
            var post = await _unitOfWork.PostRepository.GetPost(id);
            //_mapper.Map<PostDtos, Post>(postDtos, post);
            await _unitOfWork.CompleteAsync();
            post = await _unitOfWork.PostRepository.GetPost(postDtos.PostId);
            var result = _mapper.Map<Post, PostDtos>(post);
            return (result);
        }


        public async Task<LikeOnPostDto> Addlike([FromQuery] LikeOnPostDto likeDtos )
        {

            var like= _mapper.Map <LikeOnPostDto, LikeOnPost >(likeDtos);

          

            var validation = await _context.LikeOnPost.Where(w => w.UserId == likeDtos.UserId && w.PostId == likeDtos.PostId).ToListAsync();

            if (validation.Any() ) throw new Exception("exisit");
            

            _context.Add(like);

             await _unitOfWork.CompleteAsync();

             var result = _mapper.Map<LikeOnPost, LikeOnPostDto>(like);


             return (result);
           



            
        }

        public async Task<string> DeleteLike(int LikeId)
        {
            _unitOfWork.PostRepository.DeleteLike(LikeId);
            await _unitOfWork.CompleteAsync();
            return "accept deleted";

        }



        //public async Task<LikeOnPostDto> GetLike(int LikeId)
        //{
        //    var po = await _unitOfWork.PostReposito

        //    var User = await _unitOfWork.UserRepository.GetUser(post.Userid);

        //    var p = _mapper.Map<Post, PostDtos>(post);
        //    p.Username = User.UserName;

        //    return p;
        //}

        public async Task<CreateFileDto> UploadFile([FromForm] CreateFileDto fileDto)
        {

            var user = await _unitOfWork.UserRepository.GetUser(fileDto.UserId);
            var post = await _unitOfWork.PostRepository.GetPost(fileDto.Postid);


            if (user == null)
                throw new Exception("User not found");

            if (post == null)
                throw new Exception("post not Exist");

            if (fileDto.File != null)
            {
                if (fileDto.File.Length > 0)

                {
                    //Getting FileName
                    var fileName = Path.GetFileName(fileDto.File.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileDto.File.FileName);

                    var userid = fileDto.UserId;
                    var postid = fileDto.Postid;
                    // concatenating  FileName + FileExtension
                    //var newFileName = string.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);
                    var file = _mapper.Map<CreateFileDto, Modules.File>(fileDto);
                    var r = _mapper.Map<Modules.File, FileDto>(file);
                    var v = r.Username = user.UserName;
                    //return result;

                    var objfiles = new Modules.File()
                    {
                        //Username= p,
                        FileName = fileName,
                        UserId = userid,
                        PostId = postid,
                        Username = v,
                        ContentType = fileExtension

                    };

                    //var path = @"C:\\User\\DELL\\source\\repos\\FirstTask\\FirstTask\\Core\\Entities";
                    //var FileInfo = new FileInfo(path);
                    //FileInfo.CopyTo(path);

                    //using (var target = new MemoryStream())
                    //{
                    //    fileDto.File.CopyTo(target);
                    //    //    objfiles. = target.ToArray();
                    //}

                    _unitOfWork.fileRepository.Add(objfiles);
                    await _unitOfWork.CompleteAsync();

                }

                var Attachment = _mapper.Map<CreateFileDto, Modules.File>(fileDto);
                await _unitOfWork.CompleteAsync();
                var result = _mapper.Map<Modules.File, CreateFileDto>(Attachment);
                return (result);
            }
            return View();
        }

        private CreateFileDto View()
        {
            throw new NotImplementedException();
        }
    }
}
