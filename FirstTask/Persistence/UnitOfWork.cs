using AutoMapper;
using FirstTask.Core;
using FirstTask.Modules;
using FirstTask.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {

        

        private readonly PostDbContext context;
        private readonly IMapper mapper;


        public UnitOfWork(PostDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
           

            UserRepository = new UserRepository(context);
            PostRepository = new PostRepository(context,mapper);
            fileRepository = new FileRepository(context,mapper);


        }


        public IUserRepository UserRepository { get; }
        public IPostRepository PostRepository { get; }
        public IFileRepository fileRepository { get; }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
