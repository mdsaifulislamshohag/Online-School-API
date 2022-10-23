using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Course
    {
        [Key]
        public int CID { set; get; }
        [Required]
        [MaxLength(500)]

        public String Title { set; get; }
        [Required]
        public String Description { set; get; }
        [Required]
        [MaxLength(100)]
        public String Image_Path { set; get; }

        public List<Teacher_Course_Tutorial> teacher_course_tutorials { set; get; }

        public List<Admin_Course> admin_Courses { set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }
    }
}
