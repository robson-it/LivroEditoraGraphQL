﻿using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using FluentValidation;

namespace APIGraphQLHotChocolate.src.BusinessRules.Validators.Abstractions
{
    public interface ILivroValidator : IValidator<LivroMutationRequest>
    {
    }
}
