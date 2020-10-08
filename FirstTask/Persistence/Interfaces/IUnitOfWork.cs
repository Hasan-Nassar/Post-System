using FirstTask.Modules;
using FirstTask.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Core
{
    public interface IUnitOfWork
    {

         IUserRepository UserRepository { get; }
         IPostRepository PostRepository { get; }
         IFileRepository fileRepository { get; }

    
        Task CompleteAsync();
    }
}

