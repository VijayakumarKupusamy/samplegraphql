using GraphQLSample.Data;
using GraphQLSample.GQL;
using GraphQLSample.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



//InMemory Database
builder.Services.AddDbContext<DbContextClass>(o => o.UseInMemoryDatabase("GraphQLSample"));
//Register Service
builder.Services.AddTransient<IOrderService, OrderService>();
//GraphQL Config
builder.Services.AddGraphQLServer()
                .AddQueryType<OrderQuery>()
                .AddMutationType<OrderMutation>();

var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DbContextClass>();
    Seed.Initialize(services);
}

app.MapGet("/", () => "Hello World!");
 app.UseRouting()
       .UseEndpoints(endpoints =>
       {
           endpoints.MapGraphQL();
       });
app.UseHttpsRedirection();
app.Run();
