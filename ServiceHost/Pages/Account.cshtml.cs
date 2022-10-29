using AccountManagement.Application.Contract.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;

        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }

        public AccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin(Login command)
         {
            var result = _accountApplication.Login(command);

            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            LoginMessage = result.Message;

            return RedirectToPage("./Account");
        }
        public IActionResult OnGetLogout()
        {
            _accountApplication.Logout();

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostRegister(RegisterAccount command)
        {
            var result = _accountApplication.Register(command);
            RegisterMessage= result.Message;

            return RedirectToPage("/Account");
        }
    }
}
