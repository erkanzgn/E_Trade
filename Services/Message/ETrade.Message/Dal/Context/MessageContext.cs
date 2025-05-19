using ETrade.Message.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETrade.Message.Dal.Context
{
    public class MessageContext:DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options):base(options) 
        {
            
        }
        public DbSet<UserMessage> UserMessages  { get; set; }
    }
}
