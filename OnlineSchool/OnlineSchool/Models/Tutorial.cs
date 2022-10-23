using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Tutorial
    {
        [Key]
        public int TID { set; get; }
        [Required]
        [MaxLength(500)]
        public String Title { set; get; }
        [Required]
        public String Description { set; get; }
        [Required]
        [MaxLength(100)]
        public String Video_Path { set; get; }

        public List<Teacher_Course_Tutorial> 
        teacher_course_tutorials 
        
        { set; get; }

       public List<Student_Tutorial_Comment>
       Student_Tutorial_Comments

       { set; get; }

       public List<Teacher_Tutorial_Comment>
       Teacher_Tutorial_Comments

       { set; get; }

        public List<Student_Tutorial_Like>
        Student_Tutorial_Like

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
