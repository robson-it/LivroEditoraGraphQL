using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Create;
using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using APIGraphQLHotChocolate.src.BusinessRules.Validators.Abstractions;
using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Create
{
    public class EstoqueCreateHandler : IEstoqueCreateHandler
    {
        private readonly IEstoqueRepository _repository;
        private readonly IEstoqueValidator _validator;
        public EstoqueCreateHandler(IEstoqueRepository repository, IEstoqueValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public EstoqueMutationResponse Execute(EstoqueMutationRequest request)
        {

            var validatorResult = _validator.Validate(request);
            if (!validatorResult.IsValid)
            {
                return new EstoqueMutationResponse
                {
                    Errors = validatorResult.Errors
                };
            }

            Estoque entity = new Estoque(
                    request.QuantidadeEstoque
                )
            { 
                Id = Guid.NewGuid(),
                LivroId = request.LivroId
            };


            _repository.AdicionarAsync(entity);

            return new EstoqueMutationResponse
            {
                Payload = new EstoqueResponsePayload(
                    entity.QuantidadeEstoque,
                    entity.Livro
                    )
                {
                    Id = entity.Id
                }
            };

        }
    }
}
