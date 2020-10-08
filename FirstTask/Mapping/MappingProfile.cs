using AutoMapper;
using FirstTask;
using FirstTask.Core.Dtos.FileDto;
using FirstTask.Core.Dtos.LikeOnPostDto;
using FirstTask.Core.Dtos.Post;
using FirstTask.Core.Entities;
using FirstTask.Dtos;
using FirstTask.Modules;
using System.Collections.Generic;
using System.Linq;

namespace Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Post, PostDtos>().ReverseMap();
            CreateMap<Post, CreatePostDtos>().ReverseMap();
            CreateMap<File, FileDto>().ReverseMap();
            CreateMap<File, CreateFileDto>().ReverseMap();
            CreateMap<List<Post>, PostDtos>().ReverseMap();
            CreateMap<LikeOnPostDto, LikeOnPost>().ReverseMap();
            CreateMap<LikeOnPost, CreateLikeOnPostDto>().ReverseMap();
            CreateMap< CreateLikeOnPostDto, LikeOnPostDto >().ReverseMap();
            CreateMap< ApplicationUser, UserDto >().ReverseMap();
            CreateMap< ApplicationUser, CreateUserDto >().ReverseMap();


        }
    }
}



