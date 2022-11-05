using CarroAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("CarroConnection");

// Add services to the container.
//builder.Services.AddDbContext<CarroContext>(opts=>opts.UseMySQL(("CarroConnection")));
builder.Services.AddDbContext<CarroContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("CarroConnection"), new MySqlServerVersion(new Version(8, 0))));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
