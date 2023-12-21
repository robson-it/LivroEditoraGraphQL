using APIGraphQLHotChocolate.src.Database.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGraphQLHotChocolate.src.Database.Domain
{
    public class Livro : IEntity
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Autor {  get; set; }
        public string Categoria { get; set; }
        public decimal Preco {  get; set; }
        public int AnoFabricacao { get; set; }
        public Guid EditoraId {  get; set; }
        public virtual Editora? Editora { get; set; }

        [InverseProperty("Livro")]
        public virtual Estoque? Estoque { get; set; }

        public Livro(string nome, string autor, string categoria, decimal preco, int anoFabricacao) 
        {
            Nome = nome;
            Autor = autor;
            Categoria = categoria;
            Preco = preco;
            AnoFabricacao = anoFabricacao;
        }
    }
}
