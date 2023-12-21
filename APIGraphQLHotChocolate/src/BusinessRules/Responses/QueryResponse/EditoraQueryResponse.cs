using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using FluentValidation.Results;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.QueryResponse
{
    public class EditoraQueryResponse
    {
        public IQueryable<EditoraResponsePayload> Payload { get; set; }

    }
}
