using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiLivrosMeusDados.Data;
using ApiLivrosMeusDados.Models; // 👈 Importa MeusDados

[ApiController]
[Route("api/[controller]")]
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
        return await _context.MeusDados.ToListAsync();
    }

    // GET: api/MeusDados/1
    [HttpGet("{id}")]
    public async Task<ActionResult<MeusDados>> GetMeusDado(int id)
    {
        var dado = await _context.MeusDados.FindAsync(id);
        if (dado == null) return NotFound();
        return dado;
    }

    // POST: api/MeusDados
    [HttpPost]
    public async Task<ActionResult<MeusDados>> PostMeusDado(MeusDados dado)
    {
        _context.MeusDados.Add(dado);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMeusDado), new { id = dado.Id }, dado);
    }

    // PUT: api/MeusDados/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMeusDado(int id, MeusDados dado)
    {
        if (id != dado.Id) return BadRequest();
        _context.Entry(dado).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/MeusDados/1
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
