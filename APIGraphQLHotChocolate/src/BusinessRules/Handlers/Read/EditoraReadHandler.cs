using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Read;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse;
using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Repositories.Abstractions;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Read
{
    public class EditoraReadHandler : IEditoraReadHandler
    {
        private readonly IEditoraRepository _repository;

        public EditoraReadHandler(IEditoraRepository repository)
        {
            _repository = repository;
 
        }

        public EditoraQueryResponse Execute(Guid? id = null)
        {

            List<EditoraResponsePayload> editoras;
            if (id.HasValue)
            {
                editoras = _repository.ObterAsync()
                .Where(x => x.Id == id)
                .Select(q => new EditoraResponsePayload(
                    q.Nome,
                    q.Email,
                    q.Telefone,
                    q.Livros
                    )
                {
                    Id = q.Id
                })
                .ToList();
            }
            else
            {
                editoras = _repository.ObterAsync()
                .Select(q => new EditoraResponsePayload(
                    q.Nome,
                    q.Email,
                    q.Telefone,
                    q.Livros
                    )
                {
                    Id = q.Id
                })
                .ToList();
            };
                

            var retorno = new EditoraQueryResponse
            {
                Payload = editoras.AsQueryable()
            };

            return retorno;
        }
    }
}
