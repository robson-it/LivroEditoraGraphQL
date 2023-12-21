using APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Read
{
    public interface IEstoqueReadHandler
    {
        EstoqueQueryResponse Execute();
    }
}
