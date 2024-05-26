using System;

namespace BLOG.WEB.Models.Domain
{
	public class Person
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DOB { get; set; }
		public string Gender { get; set; }
		public int Mobile { get; set; }
		public int RollNumber { get; set; }
		public string Address { get; set; }
        //public int ClassNameId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		//public int ClassNameId { get; set; }
		//public ClassName className { get; set; }
    }
}

