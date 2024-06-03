using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SnackisApi.Models;

namespace SnackisApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<MainCategory> MainCategory { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
    }

}
