var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (!String.IsNullOrWhiteSpace(builder.Configuration["ApplicationInsights:InstrumentationKey"]))
    builder.Services.AddApplicationInsightsTelemetry(
        builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();