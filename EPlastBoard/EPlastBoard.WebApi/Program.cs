using EPlastBoard.BLL.Interfaces.Columns;
using EPlastBoard.BLL.Services.Columns;
using EPlastBoard.DAL.Repositories.Interfaces;
using EPlastBoard.DAL.Repositories.Realization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EPlastBoard.DAL.EPlastBoardDBContext>();
builder.Services.AddScoped<IColumnService, ColumnService>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

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
