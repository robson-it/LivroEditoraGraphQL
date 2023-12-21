using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Read;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Read
{
    public class EstoqueReadHandler : IEstoqueReadHandler
    {
        private readonly IEstoqueRepository _repository;

        public EstoqueReadHandler(IEstoqueRepository repository)
        {
            _repository = repository;
        }

        public EstoqueQueryResponse Execute()
        {
            var estoque = _repository.ObterAsync()
                .Select(q => new EstoqueResponsePayload(
                    q.QuantidadeEstoque,
                    q.Livro
                    )
                {
                    Id = q.Id,
                    LivroId = q.LivroId
                })
                .ToList();

            var retorno = new EstoqueQueryResponse
            {
                Payload = estoque.AsQueryable()
            };

            return retorno;
        }
    }
}
