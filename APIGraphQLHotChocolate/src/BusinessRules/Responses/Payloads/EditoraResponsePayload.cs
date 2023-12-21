using APIGraphQLHotChocolate.src.Database.Domain;
using APIGraphQLHotChocolate.src.Database.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGraphQLHotChocolate.src.BusinessRules.Responses.Payloads
{
    public class EditoraResponsePayload : IEntity
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [UseFiltering]
        public virtual ICollection<Livro>? Livros { get; set; }

        public EditoraResponsePayload(string nome, string telefone, string email, ICollection<Livro> livros) 
        {
            Nome = nome;
            Telefone = telefone;    
            Email = email;
            Livros = livros;
        }
    }
}
