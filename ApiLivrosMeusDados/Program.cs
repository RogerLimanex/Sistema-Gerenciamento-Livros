using Microsoft.EntityFrameworkCore;
using ApiLivrosMeusDados.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Adiciona os controladores (API REST)
builder.Services.AddControllers();

// Adiciona suporte ao Swagger (documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Garante que o banco de dados existe e aplica as migrações
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Swagger sempre disponível (acessível manualmente em /swagger)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Permite servir arquivos estáticos (index.html em wwwroot)
app.UseStaticFiles();

app.UseAuthorization();

// Controllers (API)
app.MapControllers();

// Caso nenhuma rota seja encontrada, retorna index.html
app.MapFallbackToFile("index.html");

app.Run();
