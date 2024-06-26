using AM.Domain.Core.AccountAgg.AppServices;
using AM.Domain.Core.AccountAgg.DTOs;
using Base_Framework.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.RazorPages.Pages
{
    public class AccountModel : PageModel
    {
        public string Message { get; set; }
        public string SuccessRegisterMessage { get; set; }

        [BindProperty]
        public RegisterAccountDTO RegisterModel { get; set; }


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
            Message = result.Message;

            if (result.IsSuccedded)
                return RedirectToPage("/Index", new { message = Message });

            return Page();
        }

        public async Task<IActionResult> OnGetLogout(CancellationToken cancellationToken)
        {
           await _accountAppService.Logout(cancellationToken);
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostRegister(CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
                return Page();

            var result = await _accountAppService.Register(RegisterModel, cancellationToken);
            if (result.IsSuccedded)
            {
                SuccessRegisterMessage = result.Message;
                return Page();
            }
            Message = result.Message;
            return Page();

           
        }
    }
}
