using Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAO
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
			:base(options)
		{

		}
		public DbSet<UserGroup> UserGroup { get; set; }
		public DbSet<Users> Users { get; set; }
		public DbSet<GenreInfo> GenreInfo { get; set; }

	}
}
