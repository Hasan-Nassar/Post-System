using AutoMapper;
using FirstTask.Core;
using FirstTask.Dtos;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using FirstTask.Services.Interfaces;

namespace FirstTask.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;

        //private readonly IValidator<CreateUserDtos> _validator;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IUserServices userServices/*,IValidator<CreateUserDtos> validator*/)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userServices = userServices;
            //_validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDtos) => 
            Ok(await _userServices.CreateUser(createUserDtos));

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUser(string UserId) => Ok(await _userServices.GetUser(UserId));


        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAll([FromQuery] int? pageIndex, [FromQuery] int? pageSize) => Ok(await _userServices.GetAll(pageIndex, pageSize));

        [HttpDelete("UserId")]
        public async Task<IActionResult> DeleteUser(string UserId) => Ok(await _userServices.DeleteUser(UserId));

        [HttpPut("Userid")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDto userDtos) => Ok(await _userServices.UpdateUser(id, userDtos));


    }
}
