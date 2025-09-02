using System.ComponentModel.DataAnnotations;

namespace ApiLivrosMeusDados.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autores { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public int Ano { get; set; }
    }
}
