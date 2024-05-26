using System;


namespace BLOG.WEB.Models.Domain
{
	public class Subject
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ClassNameId { get; set; }
        public ClassName className { get; set; }
       
    }
}

