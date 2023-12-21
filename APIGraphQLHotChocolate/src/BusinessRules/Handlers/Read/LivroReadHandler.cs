using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Read;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Read
{
    public class LivroReadHandler : ILivroReadHandler
    {
        private readonly ILivroRepository _repository;

        public LivroReadHandler(ILivroRepository repository)
        {
            _repository = repository;
        }

        public LivroQueryResponse Execute()
        {
            var livros = _repository.ObterAsync()
                .Select(q => new LivroResponsePayload(
                    q.Nome,
                    q.Autor,
                    q.Categoria,
                    q.Preco,
                    q.AnoFabricacao,
                    q.Editora,
                    q.Estoque
                    )
                {
                    Id = q.Id,
                    EditoraId = q.EditoraId
                })
                .ToList();

            var retorno = new LivroQueryResponse
            {
                Payload = livros.AsQueryable()
            };

            return retorno;
        }
    }
}
