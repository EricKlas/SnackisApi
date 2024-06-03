using Microsoft.EntityFrameworkCore;
using SnackisApi.Data;
using SnackisApi.Models;

namespace SnackisApi.DAL
{
    public class DatabaseInfoService : IDatabaseInfoService
    {
        private readonly DataContext _context;

        public DatabaseInfoService(DataContext context)
        {
            _context = context;
        }

        public async Task<DatabaseInfo> GetDbInfoCount()
        {
            DatabaseInfo databaseInfo = new DatabaseInfo();
            string excludedPhrase1 = "Comment has been deleted by user!";
            string excludedPhrase2 = "Comment has been deleted!";

            var mainCategories = await _context.MainCategory.ToListAsync();
            var subCategories = await _context.SubCategory.ToListAsync();
            var posts = await _context.Post.ToListAsync();
            var comments = await _context.Comment.ToListAsync();
            var users = await _context.AspNetUsers.ToListAsync();

            databaseInfo.MainCategoryCount = mainCategories.Count(m => m.Archived == false);
            databaseInfo.ArchivedMainCategoryCount = mainCategories.Count(m => m.Archived == true);
            databaseInfo.SubCategoryCount = subCategories.Count(s => s.Archived == false);
            databaseInfo.ArchivedSubCategoryCount = subCategories.Count(s => s.Archived == true);
            databaseInfo.PostCount = posts.Count();
            databaseInfo.CommentCount = comments.Count(c =>
            posts.Any(p => p.Id == c.PostId) && c.TextContent != excludedPhrase1 && c.TextContent != excludedPhrase2);
            databaseInfo.RegistratedUserCount = users.Count();

            return databaseInfo;
        }
    }
}
