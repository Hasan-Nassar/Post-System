using AutoMapper;
using FirstTask.Core;
using FirstTask.Core.Dtos.FileDto;
using FirstTask.Core.Dtos.LikeOnPostDto;
using FirstTask.Core.Dtos.Post;
using FirstTask.Dtos;
using FirstTask.Modules;
using FirstTask.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Services.Interfaces
{
    public interface IPostService
    {
        Task<PostDtos> Addpost([FromBody] CreatePostDtos postDto);
        Task<string> DeletePost(int PostId);
        Task<PostDtos> GetPost(int PostId);
        Task<PagingResultPostDto> GetAll([FromQuery] int? pageIndex, [FromQuery] int? pageSize);
        Task<PagingResultPostDto> GetAllComment([FromQuery] int? pageIndex, [FromQuery] int? pageSize, int postId);
        Task<PostDtos> UpdatePost(int id, [FromBody] PostDtos postDtos);
        Task<LikeOnPostDto> Addlike([FromBody] LikeOnPostDto likeDtos);
        Task<string> DeleteLike(int LikeId);
        Task<CreateFileDto> UploadFile([FromForm] CreateFileDto fileDto);
    }
}



