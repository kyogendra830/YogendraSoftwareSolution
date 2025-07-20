using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Linq;
using System.Threading.Tasks;
using YogendraSoftwareSolution.BAL.IServce;
using YogendraSoftwareSolution.DAL.Data;
using YogendraSoftwareSolution.Model.ViewModel;
using System.Configuration;
using System;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace YogendraSoftwareSolution.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountServices _account;

        private readonly ApplicationDbContext _context;
        public AccountController(IAccountServices account, ApplicationDbContext context)
        {
            _account = account;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var User = from m in _context.Tbl_Registration select m;
                User = User.Where(s => s.Email.Contains(loginViewModel.Email));
                if (User.Count() != 0)
                {
                    if (User.First().Password == loginViewModel.Password)
                    {
                        return RedirectToAction("SignUp");
                    }
                }
            }
            return RedirectToAction("Fail");
            //return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegistrationViewModel registrationView)
        {
            await _account.SaveRegistration(registrationView);
            ModelState.Clear();
            return View();
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> IsUsernameValidate(string Username)
        {
            bool status = true;
            var exists = await _account.ValidateUsername(Username);
            //var exists = await  _context.Tbl_Registration.Where(x => x.Username == Username).FirstOrDefaultAsync();
            if (exists != null)
            {
                status = false;
            }
            return Json(status);
            #region New code for remote validator
            //bool exists = await _account.ValidateUsername(Username);
            //if (exists)
            //    return Json(data: false);
            //else
            //    return Json(data: true);
            #endregion
        }
        [AcceptVerbs("Get", "Post")]
        public async Task<JsonResult> CheckUsername(string username)
        {
            // Perform the validation logic here
            bool isUsernameValid = await _account.ValidateUsername(username);

            if (isUsernameValid)
            {
                return Json(true);
            }
            else
            {
                return Json("Username is already taken.");
            }
        }
        public async Task<IActionResult> ForgotPassword()
        {
            //SendEmail(email);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            //SendEmail(email);
            SendEmail2();
            return RedirectToAction("Login");
        }
        //private void SendEmail(string UserName, string Subject, string Title, string Url, string Description, string Recipient)
        private void SendEmail(string UserName)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                mailMessage.From = new MailAddress("kyogendra830@gmail.com");
                mailMessage.Subject = "Your Password !";
                mailMessage.Body = "Hi";
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add("sonuak8756@gmail.com");
                //Belw
                SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";

                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                //NetworkCred.UserName = "kyogendra830@gmail.com";
                //NetworkCred.Password = "yoInd@123";
                //smtp.EnableSsl = true;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 25;
                smtp.Credentials = new NetworkCredential("kyogendra830@gmail.com", "ehvbgxzhdtivjknl", "smtp.gmail.com");
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;

                smtp.Send(mailMessage);
            }
        }
        public void SendEmail2()
        {
            string fromMail = "kyogendra830@gmail.com";
            string fromPassword = "vdljmzfankzeaxre";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Test Subject";
            message.To.Add(new MailAddress("kyogendra830@gmail.com"));
            message.Body = "<html><body> Dear Yogendra </body></html>";

            message.Priority = MailPriority.High;
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }

        public ActionResult Changepassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Changepassword(LoginViewModel login)
        {
            //var detail = db.tblUsers.Where(log => log.Password == login.Password
            //&& log.email == login.email).FirstOrDefault();
            //if (detail != null)
            //{
            //    userDetail.Password = login.NewPassword;
            //    db.SaveChanges();
            //    ViewBag.Message = "Record Inserted Successfully!";
            //}
            //else
            //{
            //    ViewBag.Message = "Password not Updated!";
            //}
            return View(login);
        }
    }
}
