using System.ComponentModel.DataAnnotations;

namespace ApiLivrosMeusDados.Models
{
    // Modelo que representa os DADOS PESSOAIS do aluno
    public class MeusDados
    {
        // Define que esta propriedade é a chave primária
        public int Id { get; set; }
        // Nome completo
        public string Nome { get; set; } = string.Empty;
        // Número de Registro Único (RU) do aluno
        public string RU { get; set; } = string.Empty;
        // Curso em que o aluno está matriculado
        public string Curso { get; set; } = string.Empty;
    }
}