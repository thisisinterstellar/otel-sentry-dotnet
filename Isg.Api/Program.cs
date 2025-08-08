using Sentry.Extensibility;

#pragma warning disable SENTRY0001
var builder = WebApplication.CreateBuilder(args);

var sentryDsn = builder.Configuration.GetValue<string>("Sentry:Dsn");

builder.WebHost.UseSentry(options =>
{
    options.Dsn = sentryDsn;
    options.Debug = true;
    options.SendDefaultPii = true;
    options.MaxRequestBodySize = RequestSize.Always;
    options.MinimumBreadcrumbLevel = LogLevel.Debug;
    options.MinimumEventLevel = LogLevel.Debug;
    options.AttachStacktrace = true;
    options.DiagnosticLevel = SentryLevel.Debug;
    options.TracesSampleRate = 1.0;
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
