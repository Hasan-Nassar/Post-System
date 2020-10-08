using FirstTask.Core;
using FirstTask.Core.Entities;
using FirstTask.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Persistence
{
    public class UserRepository : BaseRepository<ApplicationUser> ,  IUserRepository 
    {
        private readonly PostDbContext context;

        public UserRepository(PostDbContext context) : base(context)
        {
            this.context = context;
        }



        public async Task<ApplicationUser> GetUser(string userId)
        {

            //return await context.ApplicationUser
            //    .SingleOrDefaultAsync(u => u.Id == userId);
            ApplicationUser result = new ApplicationUser();
            var query = context.ApplicationUser.Select(w =>
            new UserDto
            {
                Email = w.Email,
                Id = w.Id,
                UserName = w.UserName,
                PasswordHash = w.PasswordHash,
                //Files = w.Files
            });

            result.Result = await query.ToListAsync();
            return result;

        }


        public void Remove(string Id)
        {
            var user = context.ApplicationUser.Find(Id);
            if (user == null)
                throw new Exception("User Not Found! ");

            var users = context.ApplicationUser.Where(p => p.Id == Id).ToList();
            var PostInUser = context.Posts.Where(p => p.UserId == Id).ToList();

            if (PostInUser.Count > 0)
            {
                context.Posts.RemoveRange(PostInUser);
            }
            foreach (var u in users)
            {
                Remove(user.Id);
                var users1 = context.ApplicationUser.Where(fi => fi.Id == Id).ToList();
                if (users.Count > 0)
                {
                    context.ApplicationUser.RemoveRange(users);
                }
                context.ApplicationUser.Remove(user);
            }
            context.ApplicationUser.Remove(user);
            //context.User.Include(a => a.UserId).Include(a => a.Files);
            //context.User.RemovePost(Id);
        }



        public async Task<PagingResultUserDto> GetAll(int? pageIndex, int? pageSize)
        {
            if (pageIndex <= 0) pageIndex = 1;
            if (pageSize <= 0) pageIndex = 10;

            PagingResultUserDto result = new PagingResultUserDto();

            result.TotalCount = await context.ApplicationUser.CountAsync();

            var query = context.ApplicationUser.Select(w => 
            new UserDto
            {
                Email= w.Email,
                Id = w.Id,
                UserName= w.UserName,
                PasswordHash=w.PasswordHash,
                //Files=w.Files
            }).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
         result.Result =await query.ToListAsync();

            return result;
        }



       
    }

    
}



