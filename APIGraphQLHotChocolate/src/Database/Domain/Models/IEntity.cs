using System.ComponentModel.DataAnnotations;

namespace APIGraphQLHotChocolate.src.Database.Domain.Models
{
    public abstract class IEntity
    {
        [Key]
        public Guid? Id { get; set; }

    }
}
