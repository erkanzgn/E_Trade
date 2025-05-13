using ETrade.Comment.Entites;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Comment.Context
{
    public class CommentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog =ETradeCommentDb;trustservercertificate=true;User=sa ;password=123456aA*"); ;
        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
