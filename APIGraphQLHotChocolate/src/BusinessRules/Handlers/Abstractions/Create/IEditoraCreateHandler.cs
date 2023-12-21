using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Create
{
    public interface IEditoraCreateHandler
    {
        EditoraMutationResponse Execute(EditoraMutationRequest resquest);
    }
}
