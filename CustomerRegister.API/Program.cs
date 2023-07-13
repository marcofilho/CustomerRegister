using CustomerRegister.API.Filters;
using CustomerRegister.Application.Commands.CreateCustomer;
using CustomerRegister.Application.Validators.Customers;
using CustomerRegister.Core.Repositories;
using CustomerRegister.Infra.Persistence;
using CustomerRegister.Infra.Persistence.Repositories;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddSingleton(sp =>
{
    var configuration = sp.GetService<IConfiguration>();
    var options = new MongoDbOptions();

    configuration.GetSection("Mongo").Bind(options);

    return options;
});

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var options = sp.GetService<MongoDbOptions>();

    return new MongoClient(options.ConnectionString);

});

builder.Services.AddTransient(sp =>
{
    BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

    var options = sp.GetService<MongoDbOptions>();
    var mongoClient = sp.GetService<IMongoClient>();

    return mongoClient.GetDatabase(options.Database);

});

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)))
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerClientCommandValidator>());

builder.Services.AddControllers();

builder.Services.AddMediatR(typeof(CreateCustomerCommand));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientsRegister.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientsRegister.API v1"));

}
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();