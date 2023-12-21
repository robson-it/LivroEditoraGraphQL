using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Read;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;

using APIGraphQLHotChocolate.src.Database.Domain;

namespace APIGraphQLHotChocolate.src.Api
{
    public class Query
    {


        [UseFiltering]
        public IQueryable<EditoraResponsePayload> Editoras([Service] IEditoraReadHandler handler)
        {
            return handler.Execute().Payload.AsQueryable();
        }


        [UseFiltering]
        public IQueryable<EstoqueResponsePayload> Estoque([Service] IEstoqueReadHandler handler)
        {
            return handler.Execute().Payload.AsQueryable();
        }

        [UseFiltering]
        public IQueryable<LivroResponsePayload> Livros([Service] ILivroReadHandler handler)
        {
            return handler.Execute().Payload.AsQueryable();
        }

    }
}
