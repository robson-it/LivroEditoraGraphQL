using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Domain.Models;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads
{
    public class EstoqueResponsePayload : IEntity
    {
        public Guid? Id { get; set; }
        public int QuantidadeEstoque {  get; set; }

        public Guid LivroId { get; set; }

        [UseFiltering]
        public virtual Livro? Livro { get; set; }

        public EstoqueResponsePayload(int quantidadeEstoque, Livro livro)
        {
            QuantidadeEstoque = quantidadeEstoque;
            Livro = livro;
        }
    }
}
