using ExampleGraphQL.Context;
using ExampleGraphQL.Models;

namespace ExampleGraphQL.GraphQL
{
    public class Query
    {
        // using HotChocolate package to create a GraphQL API
        [UseDbContext(typeof(ApplicationDbContext))] // to enable multiple instances of the ApplicationDbContext for every complex query not necessary for simple queries
        //public IQueryable<Video> GetVideos([Service] ApplicationDbContext context) // for common queries and one instance of the ApplicationDbContext
        [UseProjection] // enable projections this enables the client to specify the fields that they want to receive from the server for example equivalent to include() in EF Core
        [UseFiltering] // enable filtering
        [UseSorting] // enable sorting
        public IQueryable<Video> GetVideos([ScopedService] ApplicationDbContext context)
        {
            return context.Videos;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Director> GetDirectors([ScopedService] ApplicationDbContext context)
        {
            return context.Directores;
        }
    }
}
