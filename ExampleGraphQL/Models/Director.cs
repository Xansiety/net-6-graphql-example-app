using ExampleGraphQL.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleGraphQL.Models
{
    public class Director : BaseDomainModel
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // Computed field
        [NotMapped]
        public string FullName => $"{Name} {LastName}";

        // ONE TO MANY
        public virtual ICollection<Video> Videos { get; set; } = new HashSet<Video>();
    }
}
