using APIGraphQLHotChocolate.src.Database.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGraphQLHotChocolate.src.Database.Domain
{
    public class Estoque : IEntity
    {
        public Guid? Id { get; set; }
        public int QuantidadeEstoque {  get; set; }
        public Guid LivroId { get; set; }
        public virtual Livro Livro { get; set; }

        public Estoque(int quantidadeEstoque)
        {
            QuantidadeEstoque = quantidadeEstoque;

        }
    }
}
