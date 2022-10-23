using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class Admin_Course
    {
        [Key]
        public int AC { set; get; }

        [ForeignKey("Admin")]
        public int ADID { set; get; }

        public Admin Admin { set; get; }

        [ForeignKey("Course")]
        public int CID { set; get; }

        public Course Course { set; get; }
        [Required]
        public int AuthID { set; get; }

        //[ForeignKey("Authorization")]
        //public int AuthID { set; get; }

        //public Authorization Authorization { set; get; }
    }
}
