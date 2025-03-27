using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AAuthentic.API.Controllers
{
    [Route("controller")]
    [ApiController]
    public class OAuthController: ControllerBase
    {
        [Authorize]
        public async Task<IActionResult> Authorize()
        {

        }
    }
}
