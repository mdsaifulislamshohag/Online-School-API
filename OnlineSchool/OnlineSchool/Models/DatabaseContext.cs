using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSchool.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Tutorial> Tutorial { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Authorization> Authorizations { get; set; }

        public DbSet<Teacher_Course_Tutorial> Teacher_Course_Tutorial { get; set; }
        public DbSet<Student_Tutorial_Comment> Student_Tutorial_Comment { get; set; }
        public DbSet<Student_Tutorial_Like> Student_Tutorial_Like { get; set; }
        public DbSet<Teacher_Tutorial_Comment> Teacher_Tutorial_Comment { get; set; }
        public DbSet<Teacher_Tutorial_Like> Teacher_Tutorial_Like { get; set; }
        public DbSet<Admin_Course> Admin_Courses { get; set; }
        

    }
}
