using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Infrastructure;
using DataRiskIntelligence.Infrastructure.Services;
using DataRiskIntelligence.Persistance;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataRiskDbContext>();
builder.Services.AddScoped<ICrudService<Person>, PersonService>();
builder.Services.AddScoped<ICrudService<Quote>, QuoteService>();
builder.Services.AddMediatR(typeof(InfrustructureAssemblyHelper).Assembly);
builder.Services.AddAutoMapper(typeof(InfrustructureAssemblyHelper).Assembly);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
