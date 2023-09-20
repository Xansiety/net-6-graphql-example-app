using ExampleGraphQL.Models.Common;

namespace ExampleGraphQL.Models
{
    public class Video : BaseDomainModel
    {
        public string? Name { get; set; }

        public int StreamerId { get; set; }

        // virtual significa que puede ser sobrescrito por una clase derivada (heredada) en el futuro
        public virtual Streamer? Streamer { get; set; }


        // Relación uno a uno -> un video tiene un director 
        public int? DirectorId { get; set; }
        public virtual Director? Director { get; set; } 
    }
}
