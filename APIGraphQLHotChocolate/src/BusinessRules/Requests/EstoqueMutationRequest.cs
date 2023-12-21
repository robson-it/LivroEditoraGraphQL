using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Domain.Models;

namespace APIGraphQLHotChocolate.src.BusinessRules.Requests
{
    public class EstoqueMutationRequest : IEntity
    {
        public Guid? Id { get; set; }
        public int QuantidadeEstoque {  get; set; }
        public Guid LivroId { get; set; }
        public virtual Livro? Livro { get; set; }

        public EstoqueMutationRequest(int quantidadeEstoque)
        {
            QuantidadeEstoque = quantidadeEstoque;
        }
    }
}
