using ApiLivrosMeusDados.Models;
using Microsoft.EntityFrameworkCore;
using ApiLivrosMeusDados.Data;

namespace ApiLivrosMeusDados.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<MeusDados> MeusDados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Livros (atenção: Autores no plural)
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Titulo = "Programação Back End II",
                    Autores = "LEDUR, Cleverson Lopes",
                    Editora = "SAGAH",
                    Cidade = "Porto Alegre",
                    Ano = 2019
                },
                new Book
                {
                    Id = 2,
                    Titulo = "Programação Back End III",
                    Autores = "FREITAS, Pedro H. Chagas [et al.]",
                    Editora = "SAGAH",
                    Cidade = "Porto Alegre",
                    Ano = 2021
                },
                new Book
                {
                    Id = 3,
                    Titulo = "Ajax, RICH Internet Applications e desenvolvimento Web para programadores",
                    Autores = "DEITEL, Paul J.",
                    Editora = "Pearson Prentice Hall",
                    Cidade = "São Paulo",
                    Ano = 2008
                }
            );

            // Seus dados
            modelBuilder.Entity<MeusDados>().HasData(
                new MeusDados
                {
                    Id = 1,
                    Nome = "Roger de Oliveira Lima",
                    RU = "3842061",
                    Curso = "Analise e Desenvolvimento de Sistemas"
                }
            );
        }
    }
}