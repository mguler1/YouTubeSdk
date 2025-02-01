using YouTubeWebApi.Infrastructure.Context;
using YouTubeWebApi.Infrastructure.EndPoints;
using YouTubeWebApi.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<VideoService>();
builder.Services.AddDbContext<YouTubeDbContext>(options =>
{
    options.LogTo(Console.WriteLine);
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapUserEndpoints();
var dbContextScope = app.Services.CreateScope();
var dbContext = dbContextScope.ServiceProvider.GetRequiredService<YouTubeDbContext>();
dbContext.Database.EnsureCreated();
app.Run();


