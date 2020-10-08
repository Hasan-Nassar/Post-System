using AutoMapper;
using FirstTask.Modules;
using FirstTask.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using File = FirstTask.Modules.File;

namespace FirstTask.Persistence
{
    public class FileRepository : IFileRepository
    {

        private readonly PostDbContext context;
        private readonly IMapper mapper;
        public FileRepository(PostDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Add(File file)
        {
            context.Files.Add(file);
        }
        public File Getfile(int fileId)
        {
            var file =  context.Files
                .SingleOrDefault(f=>f.FileId == fileId);
            return file; 

        }
    }
}

