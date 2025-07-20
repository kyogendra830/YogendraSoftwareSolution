using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogendraSoftwareSolution.BAL.IServce;
using YogendraSoftwareSolution.DAL.Data;
using YogendraSoftwareSolution.Model.Models;
using YogendraSoftwareSolution.Model.ViewModel;

namespace YogendraSoftwareSolution.BAL.Service
{
    public class AccountService : IAccountServices
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RegistrationViewModel> SaveRegistration(RegistrationViewModel registrationView)
        {
            RegistrationModel registrationModel = new RegistrationModel()
            {
                FullName = registrationView.FullName,
                Username = registrationView.Username,
                Email = registrationView.Email,
                DOB = registrationView.DOB,
                PhonenNo = registrationView.PhonenNo,   
                Password = registrationView.Password,
                Gender = registrationView.Gender,
            };
            await _context.Tbl_Registration.AddAsync(registrationModel);
            _context.SaveChanges();
            return registrationView;
        }

        public async Task<bool> ValidateUsername(string Username)
        {
            //var result = await _context.Tbl_Registration.Where(x => x.Username == Username).FirstOrDefaultAsync();

            // return true;

            var result = await _context.Tbl_Registration.AnyAsync(x => x.Username == Username);

            return !result; // Return true if the username doesn't exis
        }
    }
}
