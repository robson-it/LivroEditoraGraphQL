using APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads;
using FluentValidation.Results;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse
{
    public class LivroMutationResponse
    {
        public LivroResponsePayload Payload { get; set; }

        public List<ValidationFailure>? Errors { get; set; }
    }
}
