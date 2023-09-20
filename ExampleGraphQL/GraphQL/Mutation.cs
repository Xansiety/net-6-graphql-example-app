using ExampleGraphQL.Context;
using ExampleGraphQL.GraphQL.DataStreamers;
using ExampleGraphQL.Models;

namespace ExampleGraphQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddStreamerPayloadResponse> AddStreamerAsync(AddStreamerRecord input, [ScopedService] ApplicationDbContext context, CancellationToken cancellationToken)
        {
            try
            {
                var streamer = new Streamer();
                streamer.Name = input.name;
                streamer.Url = input.url; 

                context.Streamers.Add(streamer);
                await context.SaveChangesAsync(cancellationToken);

                return new AddStreamerPayloadResponse(streamer);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
