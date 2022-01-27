using ElasticExample.BusinessLogic.Extensions;
using ElasticExample.Data.Contexts;
using ElasticExample.Domain.Constants;
using ElasticExample.Elasticsearch.Indices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<AppDbContext>(o => o.UseSqlServer(EnvironmentConstants.ConnectionString));

var elasticSettings = new ConnectionSettings(new Uri(EnvironmentConstants.ElasticHost))
    .DefaultMappingFor<ArticleIndex>(x => x.IndexName("articles"));
services.AddSingleton<IElasticClient>(new ElasticClient(elasticSettings));
services.AddMediatR(AssemblyExtensions.GetBisunessAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
