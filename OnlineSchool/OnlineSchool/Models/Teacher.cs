using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Teacher
    {
        [Key]
        public int TeID { set; get; }
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
        [MaxLength(1000)]
        public String Profile_Image_Path { set; get; }
        [Required]
        [MaxLength(100)]
        public String Password { set; get; }
        [Required]
        [MaxLength(100)]
        public String CV_Path { set; get; }

        public List<Teacher_Course_Tutorial> 
        Teacher_Course_Tutorials 

        { set; get; }

        public List<Teacher_Tutorial_Comment>
        Teacher_Tutorial_Comments

        { set; get; }

        public List<Teacher_Tutorial_Like>
        Teacher_Tutorial_Like

        { set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }


    }
}
