using ComicManager.BusinessLogic.Extension;
using ComicManager.Database.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*
 * Custom Services region
 */
#region Custom Services
builder.Services.AddDbContext<ComicManagerDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ComicDb"));
});
ServiceExtension.AddServices(builder.Services);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
    options.AddPolicy("AllowAnyOrigin", builder => {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }));
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAnyOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
