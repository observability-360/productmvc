using ProductMVC.Services;
using Sentry;   

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://bb6f6217ec60a9718e017b1da5b98c85@o4510205197484032.ingest.de.sentry.io/4510313989472336";
    // When configuring for the first time, to see what the SDK is doing:
    o.Debug = true;
    o.Release = "product-mvc@2.1.6";
    o.Environment = "production";
});


SentrySdk.CaptureMessage("Hello Sentry");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProductService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
