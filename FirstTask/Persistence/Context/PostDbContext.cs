using FirstTask.Core.Entities;
using FirstTask.Modules;
using FirstTask.Persistence;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace FirstTask.Persistence
{
    public class PostDbContext : IdentityDbContext<ApplicationUser> 
    {


        public DbSet<Post> Posts { get; set; }
        public DbSet<Modules.File> Files { get; set; }
        public DbSet<LikeOnPost> LikeOnPost { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }



       
        public PostDbContext(DbContextOptions<PostDbContext> Options)
            : base(Options)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }

        
    }

}






public class Fix123 : IDesignTimeDbContextFactory<PostDbContext>
{
    public PostDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PostDbContext>();

        optionsBuilder.UseSqlServer("Server=localhost;Database=Task1;Trusted_Connection=True;");
        return new PostDbContext(optionsBuilder.Options);
    }
}