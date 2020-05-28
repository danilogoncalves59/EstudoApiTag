using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TagApi.Domain;
using TagApi.Repository;
using TagApi.Repository.Services;

namespace TagApi.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class HomeController : ControllerBase
    {       
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]

        
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = Repositories.Get(model.email);

            if (user == null)
                return NotFound(new { message = "Usuario ou senha invalidos" });

            var token = TokenServices.GenerateToken(user);
            user.senha = "";
            return new
            {
                user = user,
                token = token

            };
        }
    }
}