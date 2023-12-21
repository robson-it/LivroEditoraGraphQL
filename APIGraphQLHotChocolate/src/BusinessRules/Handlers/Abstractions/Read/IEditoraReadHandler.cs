using APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Read
{
    public interface IEditoraReadHandler
    {
        EditoraQueryResponse Execute(Guid? id = null);
    }
}
