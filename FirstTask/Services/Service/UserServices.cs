using AutoMapper;
using FirstTask.Core;
using FirstTask.Core.Entities;
using FirstTask.Dtos;
using FirstTask.Modules;
using FirstTask.Services.Interfaces;
using FirstTask.Validator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FirstTask.Services
{
    public class UserServices:IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        //private readonly IValidator<CreateUserDtos> _validator;

        public UserServices(IUnitOfWork unitOfWork, IMapper mapper/*,IValidator<CreateUserDtos> validator*/)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_validator = validator;
        }

        public async Task<UserDto> CreateUser([FromBody] CreateUserDto userDto) 
        {
            UserValidator createUserDtos1 = new UserValidator();
            
            if (!createUserDtos1.Validate(userDto).IsValid)
                throw new Exception("not valid...");

            var user = _mapper.Map<CreateUserDto,  ApplicationUser > (userDto);



            _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CompleteAsync();

            //User = await _unitOfWork.UserRepository.GetUser(User.UserId);


            var result = _mapper.Map<ApplicationUser, UserDto>(user);
            return result;
        }

        public async Task<string> DeleteUser(string UserId)
        {
            //var User = await _unitOfWork.UserRepository.GetUser(UserId);

            _unitOfWork.UserRepository.Remove(UserId);
            await _unitOfWork.CompleteAsync();
            //var result = _mapper.Map<User, UserDto>(User);
            return "User Deleted";
        }

        public async Task<UserDto> GetUser(string UserId)
        {
            var user = await _unitOfWork.UserRepository.GetUser(UserId);
            return (_mapper.Map<ApplicationUser, UserDto>(user));
        }

        public async Task<PagingResultUserDto> GetAll([FromQuery] int? pageIndex, [FromQuery] int? pageSize)
        {
            var user = await _unitOfWork.UserRepository.GetAll(pageIndex, pageSize);
            return (user);

        }





        public async Task<UserDto> UpdateUser(string id, [FromBody] UserDto userDtos)
        {
            var user = await _unitOfWork.UserRepository.GetUser(id);
            if (user == null)
                return NotFound();

            await _unitOfWork.CompleteAsync();

            user = await _unitOfWork.UserRepository.GetUser(user.Id);
            
            var result = _mapper.Map<ApplicationUser, UserDto>(user);

            return (result);
        }




        private UserDto NotFound()
        {
            throw new NotImplementedException("User not found");
        }
    }
}


