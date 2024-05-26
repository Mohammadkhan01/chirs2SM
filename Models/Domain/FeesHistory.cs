using System;
using System.ComponentModel.DataAnnotations;

namespace BLOG.WEB.Models.Domain
{
	public class FeesHistory
	{
		public int Id { get; set; }
		[Display(Name = "Student name")]
		public int PersonId{ get; set; }
		public Person Persons { get; set; }
		public double TotalFees { get; set; }
     
		
		public double TransportFees { get; set; }
		public double  TotalDue { get; set; }
		public int RollNumber { get; set; }
		public bool Feespaid { get; set; }
		public bool TransportFesspaid { get; set; }
		public ClassName classNames { get; set; }
		public int ClassNameId { get; set; }
	}
}

