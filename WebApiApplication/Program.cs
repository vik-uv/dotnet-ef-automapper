using MediatR;
using WebApiApplication.DB;
using WebApiApplication.Pipes;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BloggingContext).Assembly);
builder.Services.AddMediatR(typeof(BloggingContext).Assembly);
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

builder.Services.AddTransient<IBloggingContext>(provider => new BloggingContext(builder.Configuration));

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

Seeder.SeedData(builder.Services.BuildServiceProvider().GetService<IBloggingContext>());

app.Run();
