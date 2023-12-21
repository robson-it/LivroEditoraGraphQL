using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using APIGraphQLHotChocolate.src.BusinessRules.Validators.Abstractions;
using FluentValidation;

namespace APIGraphQLHotChocolate.src.BusinessRules.Validators
{
    public class LivroValidator : AbstractValidator<LivroMutationRequest>, ILivroValidator
    {
    }
}
