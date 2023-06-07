using AZBackend;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todo", () =>
{
    List<Todo> totos = new()
    {
        new()
        {
            Id = 1,
            Name = "Test",
            Done = false
        },
        new()
        {
            Id = 2,
            Name = "Fest",
            Done = true
        }
    };

    return totos;
});

app.Run();
