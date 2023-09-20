using ExampleGraphQL.Context;
using ExampleGraphQL.GraphQL;
using ExampleGraphQL.GraphQL.DataVideo;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add SQL Server support
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
// to enable complex queries from GraphQL for example: a:videos{},b:videos{},c:videos{}
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Add GraphQL support
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>() // pass the instance of the Query class to the AddQueryType method
    .AddType<VideoType>() // enable documentation for the VideoType class
    .AddProjections() // to enable projections this enables the client to specify the fields that they want to receive from the server for example equivalent to include() in EF Core
    .AddFiltering() // enable filtering
    .AddSorting(); // enable sorting

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// to enable new endpoints for GraphQL
app.UseRouting();

app.UseAuthorization();

// indicate to client that the API supports GraphQL inside of app.UseEndpoints()
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


//use Voyager to visualize the GraphQL schema
app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-ui");

app.MapControllers();

app.Run();
