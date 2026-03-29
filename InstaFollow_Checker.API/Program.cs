using InstaFollow_Checker.Application.UseCases;
using InstaFollow_Checker.Infraesttructure.DependencyInjection;
using InstaFollow_Checker.Application.Interfaces;
using InstaFollow_Checker.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<AnalyzeInstagramFollowsUseCase>();
builder.Services.AddScoped<IFollowAnalysisService, FollowAnalysisService>();
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
