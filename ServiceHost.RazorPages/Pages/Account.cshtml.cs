using AM.Domain.Core.AccountAgg.AppServices;
using AM.Domain.Core.AccountAgg.DTOs;
using Base_Framework.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.RazorPages.Pages
{
    public class AccountModel : PageModel
    {
        [TempData]
        public string LoginMessage { get; set; }

        [TempData]
        public string RegisterMessage { get; set; }


        private readonly IAccountAppService _accountAppService;

        public AccountModel(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogin(LoginAccountDTO command, CancellationToken cancellationToken)
        {
            var result =await _accountAppService.Login(command, cancellationToken);
            if (result.IsSuccedded)
                return RedirectToPage("/Index");

            LoginMessage = result.Message;
            return RedirectToPage("/Account");
        }

        public async Task<IActionResult> OnGetLogout(CancellationToken cancellationToken)
        {
           await _accountAppService.Logout(cancellationToken);
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostRegister(RegisterAccountDTO command, CancellationToken cancellationToken)
        {
         
            var result =await _accountAppService.Register(command, cancellationToken);
            if (result.IsSuccedded)
                return RedirectToPage("/Account");
            RegisterMessage = result.Message;
            return RedirectToPage("/Account");
        }
    }
}
