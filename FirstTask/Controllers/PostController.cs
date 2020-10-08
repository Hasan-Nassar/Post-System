using AutoMapper;
using FirstTask.Core;
using FirstTask.Core.Dtos.FileDto;
using FirstTask.Core.Dtos.Post;
using FirstTask.Dtos;
using FirstTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstTask.Controllers
{

    [Route("/api/[Controller]")]
    [ApiController]
    public class PostController : Controller
    {

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        //private readonly PostDbContext _context;
        private readonly IPostService _postService;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper, /*PostDbContext context*/ IPostService postService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_context = context;
            _postService = postService;
        }

        [HttpPost()]
        //[Authorize]
        public async Task<IActionResult> AddPost([FromBody] CreatePostDtos postDto) => Ok(await _postService.Addpost(postDto));


        [HttpDelete("DeleteById")]
        //[Authorize]
        public async Task<IActionResult> DeletePost(int PostId) => Ok(await _postService.DeletePost(PostId));


        [HttpGet("GetPostById")]
        //[Authorize]
        public async Task<IActionResult> GetPost(int PostId) => Ok(await _postService.GetPost(PostId));




        [HttpGet("getallPosts")]
        //[Authorize]
        public async Task<IActionResult> GetAll([FromQuery] int? pageIndex, [FromQuery] int? pageSize) => Ok(await _postService.GetAll(pageIndex, pageSize));


        [HttpGet("getallCommentsByPostId")]
        //[Authorize]
        public async Task<IActionResult> GetAllCommentByPostId([FromQuery] int? pageIndex, [FromQuery] int? pageSize, int postId) => Ok(await _postService.GetAllComment(pageIndex, pageSize,postId));



        [HttpPut("{PostId}")]
        //[Authorize]
        public async Task<IActionResult> UpdatePost(int id, [FromBody] PostDtos postDtos) => Ok(await _postService.UpdatePost(id, postDtos));


        [HttpPost("Addlike")]
        //[Authorize]
        public async Task<IActionResult> Addlike([FromBody] LikeOnPostDto likeDtos) => Ok(await _postService.Addlike(likeDtos));

        [HttpDelete("Dislike")]
        //[Authorize]
        public async Task<IActionResult> deletelike(int LikeId) => Ok(await _postService.DeleteLike(LikeId));


        [HttpPost("UploadFile")]
        //[Authorize]
        public async Task<IActionResult> UploadFile([FromForm] CreateFileDto fileDto) => Ok(await _postService.UploadFile(fileDto));
    }
}

