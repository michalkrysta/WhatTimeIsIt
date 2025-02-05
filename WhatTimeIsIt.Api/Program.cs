var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

var utcNow = DateTime.UtcNow;

app.MapGet("/whattimeisit", () => utcNow)
    .WithName("WhatTimeIsIt")
    .WithOpenApi();

app.MapGet("/whatdateisit", () => DateOnly.FromDateTime(utcNow))
    .WithName("WhatDateIsIt")
    .WithOpenApi();
app.Run();