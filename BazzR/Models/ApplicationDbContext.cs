using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bazzr.Models;

namespace BasicAuthentication.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
        public DbSet<User> Users { get; set; }
        //public DbSet<User> Users { get; set; }
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}