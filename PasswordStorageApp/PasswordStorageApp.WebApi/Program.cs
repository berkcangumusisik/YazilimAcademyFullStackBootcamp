using PasswordStorageApp.WebApi.Hubs;
using PasswordStorageApp.WebApi.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddSignalR();

// Add Cors for all origins
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<AccountsHub>("/hubs/accountsHub");

app.Run();

// Web API ile hem mobil uygulamalar hem de web uygulamalarý arasýnda veri alýþveriþi yapýlýr.
// Web Api geriye JSON(Javascriot Object Notation) formatýnda veri döndürür.
