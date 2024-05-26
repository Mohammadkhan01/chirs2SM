using System;
using BLOG.WEB.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BLOG.WEB.Data
{
	public class BlogDbContext:DbContext
	{

		public BlogDbContext(DbContextOptions options) : base(options)
		{

		}
		
		public DbSet<ClassName> ClassNames { get; set; }
     
        public DbSet<Person> Person { get; set; }
        public DbSet<Subject> Subject { get; set; }
		public DbSet<Fees> Fees { get; set; }
		public DbSet<Attendance> Attendance { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }
		
		public DbSet<FeesHistory> FeesHistory { get; set; }


    }
}

