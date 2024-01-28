using Microsoft.EntityFrameworkCore;
using Restaurant.Integration.Application.Extensions;
using Restaurant.Integration.Application.Security;
using Restaurant.Services.ShoppingCartAPI;
using Restaurant.Services.ShoppingCartAPI.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwaggerGenService();

builder.Services.AddCartServices(builder.Configuration.GetConnectionString("MSSQL"));


builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOptions"));
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOptions>();
builder.Services.AddCustomTokenAuth(tokenOptions);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
ApplyPendigMigration();
app.Run();

void ApplyPendigMigration()
{
    using var scope = app.Services.CreateScope();

    var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (_db.Database.GetPendingMigrations().Count() > 0)
        _db.Database.Migrate();
}