using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using FluentValidation.Results;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse
{
    public class EstoqueMutationResponse
    {
        public EstoqueResponsePayload Payload { get; set; }

        public List<ValidationFailure>? Errors { get; set; }
    }
}
