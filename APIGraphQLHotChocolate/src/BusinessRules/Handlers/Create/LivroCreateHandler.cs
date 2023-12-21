using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Create;
using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using APIGraphQLHotChocolate.src.BusinessRules.Validators.Abstractions;
using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;
using Azure.Messaging;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Create
{
    public class LivroCreateHandler : ILivroCreateHandler
    {
        private readonly ILivroRepository _repositoryLivro;
        private readonly IEditoraRepository _repositoryEditora;
        private readonly ILivroValidator _validator;
        public LivroCreateHandler(ILivroRepository repository, ILivroValidator validator, IEditoraRepository repositoryEditora)
        {
            _repositoryLivro = repository;
            _repositoryEditora = repositoryEditora;
            _validator = validator;
        }

        public LivroMutationResponse Execute(LivroMutationRequest request)
        {

            var validatorResult = _validator.Validate(request);
            if (!validatorResult.IsValid)
            {
                return new LivroMutationResponse
                {
                    Errors = validatorResult.Errors
                };
            }


            Livro entity = new Livro(
                request.Nome,
                request.Autor,
                request.Categoria,
                request.Preco,
                request.AnoFabricacao
            )
            {
                Id = Guid.NewGuid(),
                EditoraId = request.EditoraId,
                Editora = request.Editora
            };

            var editoras = _repositoryEditora.ObterAsync(request.EditoraId);

            foreach (var editora in editoras)
            {
                if (editora.Id != null)
                {
                    entity.Editora = editora;
                }
                
            }

            if (entity.Editora != null)
            {
                _repositoryLivro.AdicionarAsync(entity);


                return new LivroMutationResponse
                {
                    Payload = new LivroResponsePayload(
                        entity.Nome,
                        entity.Autor,
                        entity.Categoria,
                        entity.Preco,
                        entity.AnoFabricacao,
                        entity.Editora,
                        entity.Estoque
                        )
                    {
                        Id = entity.Id,
                        EditoraId = entity.EditoraId
                    }
                };
            }

            return new LivroMutationResponse
            {
                Errors = validatorResult.Errors
            };


        }
    }
}
