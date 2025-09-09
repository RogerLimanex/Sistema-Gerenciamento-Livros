using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLivrosMeusDados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        // Usuário fixo para autenticação
        private const string USERNAME = "lima";
        private const string PASSWORD = "3842061";
        private const string SECRET_KEY = "MinhaChaveSecretaSuperSegura123!"; // Chave para gerar token JWT

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Verifica se usuário e senha estão corretos
            if (login.Username != USERNAME || login.Password != PASSWORD)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });

            // Criação do token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SECRET_KEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, login.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expira em 1 hora
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return Ok(new { token = jwtToken }); // Retorna o token JWT
        }
    }

    // Modelo para receber o login
    public class LoginModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}