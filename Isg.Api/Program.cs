#pragma warning disable SENTRY0001
var builder = WebApplication.CreateBuilder(args);

SentrySdk.Init(options =>
{
    options.Dsn = "https://examplePublicKey@o0.ingest.sentry.io/0";
    options.Experimental.EnableLogs = true;
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
