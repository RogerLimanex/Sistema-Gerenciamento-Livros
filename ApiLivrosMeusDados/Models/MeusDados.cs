using System.ComponentModel.DataAnnotations;

namespace ApiLivrosMeusDados.Models
{
    public class MeusDados
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string RU { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
    }
}
