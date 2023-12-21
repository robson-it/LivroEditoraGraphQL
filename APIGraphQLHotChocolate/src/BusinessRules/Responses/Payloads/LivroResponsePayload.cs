using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads
{
    public class LivroResponsePayload : IEntity
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Autor {  get; set; }
        public string Categoria { get; set; }
        public decimal Preco {  get; set; }
        public int AnoFabricacao { get; set; }
        public Guid EditoraId { get; set; }

        [UseFiltering]
        public virtual Editora? Editora { get; set; }

        [UseFiltering]
        public virtual Estoque? Estoque { get; set; }

        public LivroResponsePayload(string nome, string autor, string categoria, decimal preco, int anoFabricacao, Editora editora, Estoque estoque)
        {
            Nome = nome;
            Autor = autor;
            Categoria = categoria;
            Preco = preco;
            AnoFabricacao = anoFabricacao;
            Editora = editora;
            Estoque = estoque;
        }
    }
}
