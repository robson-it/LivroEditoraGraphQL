using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGraphQLHotChocolate.src.BusinessRules.Requests
{
    public class EditoraMutationRequest : IEntity
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public EditoraMutationRequest(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;    
            Email = email;
        }
    }
}
