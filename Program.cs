using DinkToPdf;
using DinkToPdf.Contracts;
using VoeAirlines.Services;
using VoeAirLines.Services;
using VoeAirLinesSenai.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VoeAirlinesContext>();
builder.Services.AddTransient<AeronaveService>();
builder.Services.AddTransient<ManutencaoService>();
builder.Services.AddTransient<PilotoService>();
builder.Services.AddTransient<VooService>();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


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
