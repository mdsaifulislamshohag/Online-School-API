using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Models;
using ViewModel;

namespace OnlineSchool.Controllers
{
   
   /// [ApiController]
    [Authorize(Roles = "Student", AuthenticationSchemes = "Student")]
    public class StudentController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public StudentController(DatabaseContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [HeaderAuthorization]
        [AllowAnonymous]
        [HttpPost]
        [Route("Student/Registration")]
        public async Task<ActionResult> Registration(StudentViewModel studentView)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Input Formate not Staisfy" });
            }
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));

            var verify_Email = await _context.Student
                .Where(x => (x.Email == studentView.Email && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (verify_Email != null)
            {
                return Json(new { success = false, error = "This Email is Already in USE" });
            }



            String UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "StudentProfilePicture");
            String UniqueFileName = Guid.NewGuid().ToString() + "_" + studentView.Photo.FileName;
            String FilePath = Path.Combine(UploadFolder, UniqueFileName);
            studentView.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));

            var data = new Student
            {
                Name = studentView.Name,
                Email = studentView.Email,
                Phone = studentView.Phone,
                Address = studentView.Address,
                Password = studentView.Password,
                AuthID = Auth_ID,
                Profile_Image_Path = UniqueFileName,

            };
            _context.Student.Add(data);
            await _context.SaveChangesAsync();
            return Json(new { success = true, data = "Registration Complete" });
        }


        [HeaderAuthorization]
        [AllowAnonymous]
        [Route("Student/Login")]
        [HttpPost]
        
        public async Task<ActionResult> Login(StudentLoginViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Login Failed" });
            }

            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));

            var data = await _context.Student
                .Where(x => (x.Email == student.Email && x.Password == student.Password && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();
            if (data == null)
            {
                return Json(new { success = false, error = "Login Failed" });
            }
            else
            {
                await HttpContext.SignOutAsync("Student");
                await HttpContext.SignOutAsync("Provider");
                await HttpContext.SignOutAsync("Admin");
                await HttpContext.SignOutAsync("Teacher");

                ClaimsIdentity identity = null;
                identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Email,student.Email),
                        new Claim(ClaimTypes.Role,"Student")

                     }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("Student", principal);

                HttpContext.Session.SetString("SID", data.SID.ToString());


                return Json(new { success = true, ReturnURL = "/Student/Profile" });
            }
        }

        [HeaderAuthorization]
        [Route("Student/Profile")]
        [HttpGet]
        public async Task<ActionResult> Profile()
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int SID = Convert.ToInt32(HttpContext.Session.GetString("SID"));

            var value = await _context.Student
                .Where(x => (x.SID == SID && x.AuthID == Auth_ID))
                .Select(y => new { y.SID, y.Name, y.Email, y.Phone, y.Address, y.Profile_Image_Path })
                .FirstOrDefaultAsync();
            if (value == null)
            {
                return Unauthorized();
            }
            else
            {
                return Json(new { success = true, data = value });
            }

        }

        [HeaderAuthorization]
        [Route("Student/ProfileUpdate")]
        [HttpPost]
        public async Task<ActionResult> ProfileUpdate(StudentViewUpdateModel student)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, error = "Input Formate Wrong" });
            }

            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int SID = Convert.ToInt32(HttpContext.Session.GetString("SID"));

            var value = await _context.Student
                .Where(x => (x.SID == SID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var verify_Email = await _context.Student
               .Where(x => (x.Email == student.Email && x.SID != SID))
               .FirstOrDefaultAsync();

            if (verify_Email != null)
            {
                return Json(new { success = false, error = "This Email is Already in USE" });
            }

            value.Name = student.Name;
            value.Email = student.Email;
            value.Phone = student.Phone;
            value.Address = student.Address;
            value.Password = student.Password;

            await _context.SaveChangesAsync();

            return Json(new { success = true, data = value });
        }

        [HeaderAuthorization]
        [Route("Student/ProfileImageUpdate")]
        [HttpPost]

        public async Task<ActionResult> ProfileImageUpdate(StudentUpdateImage student)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int SID = Convert.ToInt32(HttpContext.Session.GetString("SID"));

            var value = await _context.Student
                .Where(x => (x.SID == SID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            String UploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "StudentProfilePicture");
            String UniqueFileName = Guid.NewGuid().ToString() + "_" + student.Photo.FileName;
            String FilePath = Path.Combine(UploadFolder, UniqueFileName);
            student.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));

            value.Profile_Image_Path = UniqueFileName;

            await _context.SaveChangesAsync();

            return Json(new { success = true, data = "Image Updated" });


        }

        [HeaderAuthorization]
        [Route("Student/Reaction/{TID}/{reaction}")]
        [HttpGet]
        public async Task<ActionResult> Like(int TID, int reaction)
        {

            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int SID = Convert.ToInt32(HttpContext.Session.GetString("SID"));

            var value = await _context.Student
                .Where(x => (x.SID == SID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var LID = await _context.Student_Tutorial_Like
                .Where(x => (x.SID == SID && x.AuthID == Auth_ID && x.TID == TID))
                .Select(y => new { y.LID }).FirstOrDefaultAsync();

            if (LID == null)
            {
                var like = new Like
                {
                    Likes = reaction,
                    AuthID = Auth_ID
                };
                _context.Like.Add(like);
                await _context.SaveChangesAsync();

                int newLID = like.LID;

                var joiningInsert = new Student_Tutorial_Like
                {
                    SID = SID,
                    TID = TID,
                    LID = newLID,
                    AuthID = Auth_ID
                };
                _context.Student_Tutorial_Like.Add(joiningInsert);
                await _context.SaveChangesAsync();

                return Json(new { success = true });
            }
            else
            {
                var react = await _context.Like
                    .Where(x => (x.LID == LID.LID && x.AuthID == Auth_ID))
                    .FirstOrDefaultAsync();

                react.Likes = reaction;
                await _context.SaveChangesAsync();


                return Json(new { success = true });

            }

        }

        [HeaderAuthorization]
        [Route("Student/Comment/{TID}")]
        [HttpPut]
        public async Task<ActionResult> Comment(int TID, StudentComment com)
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int SID = Convert.ToInt32(HttpContext.Session.GetString("SID"));

            var value = await _context.Student
              .Where(x => (x.SID == SID && x.AuthID == Auth_ID))
              .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }

            var ComID = await _context.Student_Tutorial_Comment
                .Where(x => (x.SID == SID && x.AuthID == Auth_ID && x.TID == TID))
                .Select(y => new { y.ComID }).FirstOrDefaultAsync();

            if (ComID == null)
            {
                var feedback = new Comment
                {
                    Comments = com.Comment,
                    AuthID = Auth_ID
                };
                _context.Comment.Add(feedback);
                await _context.SaveChangesAsync();

                int newComID = feedback.ComID;

                var joiningInsert = new Student_Tutorial_Comment
                {
                    SID = SID,
                    TID = TID,
                    ComID = newComID,
                    AuthID = Auth_ID
                };
                _context.Student_Tutorial_Comment.Add(joiningInsert);
                await _context.SaveChangesAsync();

                return Json(new { success = true, data = com.Comment });
            }
            else
            {
                var react = await _context.Comment
                    .Where(x => (x.ComID == ComID.ComID && x.AuthID == Auth_ID))
                    .FirstOrDefaultAsync();

                react.Comments = com.Comment;
                await _context.SaveChangesAsync();


                return Json(new { success = true, data = com.Comment });

            }

        }


        [HeaderAuthorization]
        [Route("Student/LogOut")]
        [HttpGet]
        public async Task<ActionResult> LogOut()
        {
            int Auth_ID = Convert.ToInt32(HttpContext.Session.GetString("Subject"));
            int SID = Convert.ToInt32(HttpContext.Session.GetString("SID"));

            var value = await _context.Student
                .Where(x => (x.SID == SID && x.AuthID == Auth_ID))
                .FirstOrDefaultAsync();

            if (value == null)
            {
                return Unauthorized();
            }


            // Check The Better Proccess
            HttpContext.Session.Remove("SID");

            await HttpContext.SignOutAsync("Student");
            await HttpContext.SignOutAsync("Provider");
            await HttpContext.SignOutAsync("Admin");
            await HttpContext.SignOutAsync("Teacher");

            return Json(new { success = true, ReturnURL = "/Home/Courses" });


        }

    }

}