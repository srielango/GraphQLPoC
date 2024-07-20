using GraphQLPoC;
using GraphQLPoC.Entities;
using GraphQLPoC.Mutations;
using GraphQLPoC.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<bookshelfContext>(opt => opt.UseSqlServer("Data Source=localhost;Initial Catalog=bookshelf;Integrated Security=true;TrustServerCertificate=True;"));

builder.Services.AddScoped<bookshelfContext>(
    options => options.GetRequiredService<IDbContextFactory<bookshelfContext>>()
    .CreateDbContext());

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    //.AddMutationType<Mutation>()
    .AddInMemorySubscriptions();
    //.AddSubscriptionType<Subscription>();


// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
app.UseWebSockets();

app.MapGraphQL();

app.Run();
