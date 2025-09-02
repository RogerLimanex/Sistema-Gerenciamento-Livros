using Microsoft.EntityFrameworkCore;
using ApiLivrosMeusDados.Data;

var builder = WebApplication.CreateBuilder(args);

// EF Core + SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Migrar e semear na subida
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Swagger sempre disponível (acessível manualmente em /swagger)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Habilita servir arquivos estáticos (wwwroot)
app.UseStaticFiles();

app.UseAuthorization();

// Controllers (API)
app.MapControllers();

// Fallback: se não encontrar rota, abre o index.html
app.MapFallbackToFile("index.html");

app.Run();
