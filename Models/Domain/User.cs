using System;
using System.ComponentModel.DataAnnotations;

namespace BLOG.WEB.Models.Domain
{
	public class User
	{
		public int Id { get; set; }
		[Required(ErrorMessage="Email is Required")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage ="User Name is Required")]
		[Display(Name ="User Name")]
		[StringLength(20)]
		[MaxLength(20)]
		public string UserName { get; set; }

		[DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [StringLength(20)]
        [MaxLength(20)]
		public string Password { get; set; }

		public bool IsActive { get; set; }
	}
}

