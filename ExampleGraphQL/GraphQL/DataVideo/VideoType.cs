using ExampleGraphQL.Models;

namespace ExampleGraphQL.GraphQL.DataVideo
{
    public class VideoType : ObjectType<Video>
    {
        // add a kind of description for the type
        protected override void Configure(IObjectTypeDescriptor<Video> descriptor)
        {
            descriptor.Description("This model is used as base for video information.");

            descriptor
                .Field(c => c.Director)
                .Description("Represents the director of the video.");
        }
    }
}
