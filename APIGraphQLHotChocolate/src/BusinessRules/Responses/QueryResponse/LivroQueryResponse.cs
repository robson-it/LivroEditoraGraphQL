using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using FluentValidation.Results;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse
{
    public class LivroQueryResponse
    {
        public IQueryable<LivroResponsePayload> Payload { get; set; }

    }
}
