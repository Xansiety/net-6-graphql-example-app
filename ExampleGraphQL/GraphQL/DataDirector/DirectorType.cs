using ExampleGraphQL.Context;
using ExampleGraphQL.Models;

namespace ExampleGraphQL.GraphQL.DataDirector
{
    public class DirectorType : ObjectType<Director>
    {
        // add a kind of description for the type
        protected override void Configure(IObjectTypeDescriptor<Director> descriptor)
        {
            descriptor.Description("This model is used as base for director information.");

            descriptor
                .Field(c => c.Videos)
                .ResolveWith<Resolvers>(x => x.GetVideos(default!, default!)) // can apply specific logic  over attribute or entity and return a specific value(s)
                .UseDbContext<ApplicationDbContext>()
                .Description("Represents the videos of the director.");

            // create a computed field
            descriptor.Field("fullName")
                .ResolveWith<Resolvers>(x => x.GetFullName(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This is the full name of the director.");


            // like as Dto to not expose the entity
            //descriptor.Ignore(c => c.Id); but for this case we need the id to get the videos
        }

        private class Resolvers
        {
            public IQueryable<Video> GetVideos([Parent] Director director, [ScopedService] ApplicationDbContext context)
            {
                return context.Videos.Where(c => c.DirectorId == director.Id);
            }

            public string GetFullName([Parent] Director director, [ScopedService] ApplicationDbContext context)
            {
                return $"{director.Name} {director.LastName}";
            }
        }
    }
}
