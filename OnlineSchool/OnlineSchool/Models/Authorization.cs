using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Authorization
    {
        [Key]
        public int AuthID { set; get; }
        [Required]
        [MaxLength(100)]
        public String Email { set; get; }
        [Required]
        [MaxLength(500)]
        public String Company_Name { set; get; }
        [Required]
        [MaxLength(1000)]
        public String JWT_Token {set;get;}


     /////   public List<Comment> comments { set; get; }

     /////   public List<Course> courses { set; get; }

     /////   public List<Like> likes { set; get; }

     //   public List<Student> students { set; get; }

     //   public List<Teacher> teachers { set; get; }

     /////   public List<Teacher> tutorials { set; get; }

     //   public List<Admin> admin { set; get; }

     // /////  public List<Admin_Course> admin_Courses { set; get; }

     //////   public List<Student_Tutorial_Comment> student_Tutorial_Comments { set; get; }

     // ///  public List<Student_Tutorial_Like> Student_Tutorial_Likes { set; get; }

     /////   public List<Teacher_Course_Tutorial> Teacher_Course_Tutorials { set; get; }

     /////   public List<Teacher_Tutorial_Comment> Teacher_Tutorial_Comments { set; get; }

     /////   public List<Teacher_Tutorial_Like> Teacher_Tutorial_Likes { set; get; }


    }
}
