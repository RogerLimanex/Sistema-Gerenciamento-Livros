using System.ComponentModel.DataAnnotations;

namespace ApiLivrosMeusDados.Models
{
    // Modelo que representa os LIVROS no sistema
    public class Book
    {
        // Define que esta propriedade é a chave primária no banco
        public int Id { get; set; }
        // Título do livro
        public string Titulo { get; set; } = string.Empty;
        // Autor ou autores do livro
        public string Autores { get; set; } = string.Empty;
        // Editora responsável pela publicação
        public string Editora { get; set; } = string.Empty;
        // Cidade de publicação
        public string Cidade { get; set; } = string.Empty;
        // Ano de publicação
        public int Ano { get; set; }
    }
}