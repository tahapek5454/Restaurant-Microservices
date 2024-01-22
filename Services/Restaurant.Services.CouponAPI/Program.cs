using Microsoft.EntityFrameworkCore;
using Restaurant.Services.CouponAPI;
using Restaurant.Services.CouponAPI.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCouponServices(builder.Configuration.GetConnectionString("MSSQL") ?? string.Empty);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

ApplyPendigMigration();

app.Run();


void ApplyPendigMigration()
{
    using var scope = app.Services.CreateScope();

    var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if(_db.Database.GetPendingMigrations().Count() > 0)
        _db.Database.Migrate();
}