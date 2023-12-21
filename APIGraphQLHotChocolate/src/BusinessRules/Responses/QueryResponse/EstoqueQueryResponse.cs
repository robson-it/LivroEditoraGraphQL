using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using FluentValidation.Results;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse
{
    public class EstoqueQueryResponse
    {
        public IQueryable<EstoqueResponsePayload> Payload { get; set; }

    }
}
