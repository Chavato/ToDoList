using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Infra.Data.Context;
using ToDoList.Infra.IoC;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin());
            });

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);

builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions
                                                  .Converters
                                                  .Add(new JsonStringEnumConverter()));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    applicationDbContext.Database.Migrate();
}

app.Run();
