using EPlastBoard.BLL.Interfaces.Boards;
using EPlastBoard.BLL.Services.Boards;
using EPlastBoard.DAL.Repositories.Interfaces;
using EPlastBoard.BLL.Interfaces.Columns;
using EPlastBoard.BLL.Services.Columns;
using EPlastBoard.DAL.Repositories.Realization;
using System.Text.Json.Serialization;
using EPlastBoard.BLL.Interfaces.Cards;
using EPlastBoard.BLL.Services.Cards;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EPlastBoard.DAL.EPlastBoardDBContext>();

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IColumnService, ColumnService>();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<IColumnService, ColumnService>();
builder.Services.AddScoped<ICardService, CardService>();

builder.Services.AddCors();

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(m => m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
