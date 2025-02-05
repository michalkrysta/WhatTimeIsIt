var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Endpoint to get current UTC time
app.MapGet("/whattimeisit", () => DateTime.UtcNow)
    .WithName("WhatTimeIsIt")
    .WithOpenApi();

// Endpoint to get current UTC date
app.MapGet("/whatdateisit", () => DateOnly.FromDateTime(DateTime.UtcNow))
    .WithName("WhatDateIsIt")
    .WithOpenApi();

app.Run();