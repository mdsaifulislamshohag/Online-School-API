using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ViewModel
{
   public class AdminRegistrationViewModel
    {
        [Required]
        [MaxLength(50)]
        public String Name { set; get; }
        [Required]
        [MaxLength(100)]
        public String Email { set; get; }
        [Required]
        [MaxLength(20)]
        public String Phone { set; get; }
        [Required]
        [MaxLength(500)]
        public String Address { set; get; }
        [Required]
        
        public IFormFile Photo { set; get; }
        [Required]
        [MaxLength(100)]
        public String Password { set; get; }


      
    }
}
