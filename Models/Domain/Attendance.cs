using System;

namespace BLOG.WEB.Models.Domain
{
	public class Attendance
	{
		public int Id { get; set; }
        public int ClassNameId { get; set; }
        public ClassName className { get; set; }
        public bool Status { get; set; }
        public DateTime attendanceDate { get; set; }
    }
}

