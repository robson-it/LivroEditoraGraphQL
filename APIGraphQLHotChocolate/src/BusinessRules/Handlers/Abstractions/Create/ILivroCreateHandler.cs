﻿using APIGraphQLHotChocolate.src.BusinessRules.Requests;
using APIGraphQLHotChocolate.src.BusinessRules.Responses.MutationResponse;

namespace APIGraphQLHotChocolate.src.BusinessRules.Handlers.Abstractions.Create
{
    public interface ILivroCreateHandler
    {
        LivroMutationResponse Execute(LivroMutationRequest resquest);
    }
}
