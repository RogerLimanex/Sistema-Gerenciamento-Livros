using Microsoft.EntityFrameworkCore;
using ApiLivrosMeusDados.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Adiciona controllers
builder.Services.AddControllers();

// Configuração da autenticação JWT
var key = Encoding.ASCII.GetBytes("MinhaChaveSecretaSuperSegura123!");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Aplica migrações automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication(); // Ativa autenticação
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
