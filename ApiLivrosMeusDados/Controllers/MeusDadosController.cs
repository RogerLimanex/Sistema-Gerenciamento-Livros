using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiLivrosMeusDados.Data;
using ApiLivrosMeusDados.Models;

// Rota base da API → /api/meusdados
[ApiController]
[Route("api/[controller]")]
public class MeusDadosController : ControllerBase
{
    private readonly AppDbContext _context;

    public MeusDadosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/meusdados → retorna todos os registros (apenas 1 no nosso caso)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MeusDados>>> GetMeusDados()
    {
        return await _context.MeusDados.ToListAsync();
    }

    // GET: api/meusdados/1 → retorna os dados pessoais
    [HttpGet("{id}")]
    public async Task<ActionResult<MeusDados>> GetMeusDado(int id)
    {
        var dado = await _context.MeusDados.FindAsync(id);
        if (dado == null) return NotFound();
        return dado;
    }

    // POST: api/meusdados → insere novos dados pessoais
    [HttpPost]
    public async Task<ActionResult<MeusDados>> PostMeusDado(MeusDados dado)
    {
        _context.MeusDados.Add(dado);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMeusDado), new { id = dado.Id }, dado);
    }

    // PUT: api/meusdados/1 → atualiza os dados
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMeusDado(int id, MeusDados dado)
    {
        if (id != dado.Id) return BadRequest();
        _context.Entry(dado).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/meusdados/1 → apaga os dados
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
