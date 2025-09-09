using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiLivrosMeusDados.Data;
using ApiLivrosMeusDados.Models;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize] // 🔒 Todos os endpoints exigem login via JWT
public class MeusDadosController : ControllerBase
{
    private readonly AppDbContext _context;

    public MeusDadosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/MeusDados
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeusDados>>> GetMeusDados()
    {
        // Retorna todos os dados pessoais
        return await _context.MeusDados.ToListAsync();
    }

    // GET: api/MeusDados/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MeusDados>> GetMeusDado(int id)
    {
        var dado = await _context.MeusDados.FindAsync(id);
        if (dado == null) return NotFound(); // 404 se não existir
        return dado;
    }

    // POST: api/MeusDados
    [HttpPost]
    public async Task<ActionResult<MeusDados>> PostMeusDado(MeusDados dado)
    {
        _context.MeusDados.Add(dado); // Adiciona novo dado
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMeusDado), new { id = dado.Id }, dado);
    }

    // PUT: api/MeusDados/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMeusDado(int id, MeusDados dado)
    {
        if (id != dado.Id) return BadRequest(); // Confere id
        _context.Entry(dado).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/MeusDados/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMeusDado(int id)
    {
        var dado = await _context.MeusDados.FindAsync(id);
        if (dado == null) return NotFound();
        _context.MeusDados.Remove(dado);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}