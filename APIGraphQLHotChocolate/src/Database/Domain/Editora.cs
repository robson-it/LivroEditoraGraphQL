using APIGraphQLHotChocolate.src.Database.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGraphQLHotChocolate.src.Database.Domain
{
    public class Editora : IEntity
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        [InverseProperty("Editora")]
        public virtual ICollection<Livro>? Livros { get; set; }

        public Editora(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;    
            Email = email;
        }
    }
}
