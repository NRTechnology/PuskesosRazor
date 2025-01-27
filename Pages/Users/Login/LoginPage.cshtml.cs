using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PuskesosRazor.Pages.Users.Login
{
    public class LoginPageModel : PageModel
    {
      private readonly SignInManager<IdentityUser> _signInManager;
      private readonly ILogger<LoginPageModel> _logger;
      private UserManager<IdentityUser> _userManager;

public LoginPageModel(SignInManager<IdentityUser> signInManager, ILogger<LoginPageModel> logger, UserManager<IdentityUser> userManager)
      {
        _signInManager = signInManager;
        _logger = logger;
        _userManager = userManager;
      }

      [BindProperty]
      public InputModel Input { get; set; }

    public class InputModel
      {
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
      }

    public void OnGet()
        {
        }

    public async Task<IActionResult> OnPostAsync()
        {
          var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
          if (result.Succeeded)
          {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
              Console.WriteLine(role);  
            }
            
            _logger.LogInformation("User logged in.");
            return LocalRedirect("/Administrator/Dashboards/Analytics");
          }
          Console.WriteLine(Input.Email);
          Console.WriteLine(Input.Password);
          Console.WriteLine(result);
          return null;
        }
    }
}
