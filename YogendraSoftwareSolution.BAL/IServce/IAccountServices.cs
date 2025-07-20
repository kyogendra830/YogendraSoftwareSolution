using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogendraSoftwareSolution.Model.ViewModel;

namespace YogendraSoftwareSolution.BAL.IServce
{
    public interface IAccountServices
    {
        Task<RegistrationViewModel> SaveRegistration(RegistrationViewModel registrationView);
        Task<bool> ValidateUsername(string Username);
    }
}
