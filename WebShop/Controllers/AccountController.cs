// Time-stamp: <2021-10-31 16:05:41 stefan>

using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebShop.Models.Entities.Identity;
using WebShop.ViewModels;

namespace WebShop.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
	private readonly ILogger<AccountController> _loggdest;
	private readonly UserManager<AppUser> _userManager;
	private readonly SignInManager<AppUser> _signInManager;

	public AccountController( ILogger<AccountController> loggdest,
				  UserManager<AppUser> userManager,
				  SignInManager<AppUser> signInManager)
	{
	    _loggdest = loggdest;
	    _userManager = userManager;
	    _signInManager = signInManager;
	}

	/// <summary>
	/// inloggning mha Identity Manager
	/// </summary>
	[HttpPost]
	public async Task<ActionResult<UserViewModel>> Login(LoginViewModel loginModel)
	{
	    var user = await _userManager.FindByEmailAsync(loginModel.Email);

	    if (user == null) return Unauthorized("You are not authorized");

	    var result = await _signInManager.CheckPasswordSignInAsync(
		user, loginModel.Password, false);

	    if (!result.Succeeded) return Unauthorized("You are not authorized");

	    return new UserViewModel
	    {
		Email = user.Email,
		DisplayName = user.DisplayName
	    };
	}

    }
}
