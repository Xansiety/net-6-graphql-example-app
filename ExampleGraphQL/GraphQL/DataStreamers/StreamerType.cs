using ExampleGraphQL.Models;

namespace ExampleGraphQL.GraphQL.DataStreamers
{
    public class StreamerType : ObjectType<Streamer>
    {
        protected override void Configure(IObjectTypeDescriptor<Streamer> descriptor)
        {
           descriptor.Description("Represents the company that produces one or more movies.");
 
        }
    }
}
