using FirstTask.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Persistence.Interfaces
{
    public interface IFileRepository
    {
        void Add(File file);
        File Getfile(int fileId);
    }
}


