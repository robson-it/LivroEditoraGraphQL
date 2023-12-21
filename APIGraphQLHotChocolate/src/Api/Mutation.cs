using APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Create;
using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse;


namespace APIGraphQLHotChocolate.src.Api
{
    public class Mutation
    {


        public EditoraMutationResponse CriarEditora([Service] IEditoraCreateHandler handler, EditoraMutationRequest request)
        {
            return handler.Execute(request);
        }

        public EstoqueMutationResponse CriarEstoque([Service] IEstoqueCreateHandler handler, EstoqueMutationRequest request)
        {
            return handler.Execute(request);
        }

        public LivroMutationResponse CriarLivro([Service] ILivroCreateHandler handler, LivroMutationRequest request)
        {
            return handler.Execute(request);
        }
    }
}
