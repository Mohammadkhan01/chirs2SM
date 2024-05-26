using System;
using System.ComponentModel.DataAnnotations;

namespace BLOG.WEB.Models.Domain
{
    public class ClassName 
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Class Name is Required")]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}

