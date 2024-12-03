using EclipseWorksAssessment.Application;
using EclipseWorksAssessment.Persistence.Context;
using EclipseWorksAssessment.WebAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.ConfigurePersistence(builder.Configuration);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EclipseWorksCs")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
});
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ServiceExtensions.MigrationInitializer(app);

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
