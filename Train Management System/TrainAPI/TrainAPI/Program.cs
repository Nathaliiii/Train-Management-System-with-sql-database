using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TrainAPI.Data;
using TrainAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
String conn = "Data Source=LAPTOP-5ETVI718;Initial Catalog=SOC;User ID=sa;Password=sql;Trust Server Certificate=True";
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<TrainRepository, TrainRepository>();
builder.Services.AddScoped<PassengerRepository, PassengerRepository>();
builder.Services.AddScoped<SeatRepository, SeatRepository>();

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(conn));
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

    builder.Services.AddEndpointsApiExplorer();


{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
