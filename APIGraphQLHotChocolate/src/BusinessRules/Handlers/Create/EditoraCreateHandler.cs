using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Create;
using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using APIGraphQLHotChocolate.src.BusinessRules.Validators.Abstractions;
using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Create
{
    public class EditoraCreateHandler : IEditoraCreateHandler
    {

        private readonly IEditoraRepository _repository;
        private readonly IEditoraValidator _validator;
        public EditoraCreateHandler(IEditoraRepository repository, IEditoraValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public EditoraMutationResponse Execute(EditoraMutationRequest request)
        {

            var validatorResult = _validator.Validate(request);
            if (!validatorResult.IsValid)
            {
                return new EditoraMutationResponse
                {
                    Errors = validatorResult.Errors
                };
            }

            Editora entity = new Editora(
                    request.Nome,
                    request.Telefone,
                    request.Email
                )
            { Id = Guid.NewGuid() };


            _repository.AdicionarAsync(entity);

            return new EditoraMutationResponse
            {
                Payload = new EditoraResponsePayload(
                    entity.Nome,
                    entity.Telefone,
                    entity.Email,
                    entity.Livros
                    )
                {
                    Id = entity.Id
                }
            };

        }

    }
}
