using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ExampleGraphQL.Models
{
    public class Streamer
    {
        public int StreamerId { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; } //= string.Empty;

        // El ICollection es una interfaz que permite acceder a una lista de elementos y puede transformarse en una lista, un array, etc.
        // Uno a muchos
        public List<Video> Videos { get; set; } = new List<Video>();
    }
}
