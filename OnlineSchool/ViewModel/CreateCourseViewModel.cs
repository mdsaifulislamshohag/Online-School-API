using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
   public class CreateCourseViewModel
    {
        [Required]
        [MaxLength(100)]
        public String Title { set; get; }
        [Required]
        public String Description { set; get; }
     
        [Required]
        public IFormFile Photo { set; get; }

        
    }
}
