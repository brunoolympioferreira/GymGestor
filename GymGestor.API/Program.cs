using GymGestor.Infra;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfra();

builder.Host.ConfigureAppConfiguration((hostContext, config) =>
{
    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.MSSqlServer(
        Environment.GetEnvironmentVariable("CS_SQLSERVER_LOCALHOST_GYM_GESTOR"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "LogEvents",
            AutoCreateSqlTable = true
        })
    .WriteTo.Console()
    .CreateLogger();
}).UseSerilog();

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

app.Run();
