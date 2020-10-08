using FirstTask.Core.Entities;
using FirstTask.Dtos;
using FirstTask.Modules;
using FirstTask.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Core
{
    public interface IUserRepository:IBaseRepository<ApplicationUser>
    {

  
    

        void Remove(string Id);

        Task<ApplicationUser> GetUser(string Id);

        Task<PagingResultUserDto> GetAll(int? pageIndex, int? pageSize);
    }
}
