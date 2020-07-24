

using Catstagram_Server.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Catstagram_Server.Data
{
   
    public class CatstagramDbContext : IdentityDbContext<User>
    {
        public CatstagramDbContext(DbContextOptions<CatstagramDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cat> Cats { get; set; }
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
