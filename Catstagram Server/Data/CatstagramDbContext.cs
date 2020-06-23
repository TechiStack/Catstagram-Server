

namespace Catstagram_Server.Data
{
    using Catstagram_Server.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class CatstagramDbContext : IdentityDbContext<User>
    {
        public CatstagramDbContext(DbContextOptions<CatstagramDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .Entity<Cat>()
                .HasOne(c => c.User) //Parent
                .WithMany(u => u.Cats) //Childs
                .HasForeignKey(c => c.UserId) //FK Reletion
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
