using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BLL.ModelVM.User
{
    public class CreateUserVM
    {
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(30, ErrorMessage ="The length must have at most 30 char")]
        [MinLength(3, ErrorMessage ="The length must have at least 3 char")]
        public string Name { get; set; }
        [Range(12,80, ErrorMessage ="Age must be between 12 and 80")]
        public int Age { get; set; }
        public IFormFile image { get; set; }
        [Required(ErrorMessage ="This is required")]
        public int DeptId { get; set; } 
    }
}
