using FirstTask.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Services.Interfaces
{
    public interface IUserServices
    {
        Task<UserDto> CreateUser([FromBody] CreateUserDto userDto);
        Task<string> DeleteUser(string UserId);
        Task<UserDto> GetUser(string UserId);
        Task<PagingResultUserDto> GetAll([FromQuery] int? pageIndex, [FromQuery] int? pageSize);
        Task<UserDto> UpdateUser(string id, [FromBody] UserDto userDtos);

    }
}
