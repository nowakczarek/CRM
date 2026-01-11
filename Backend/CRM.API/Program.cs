using CRM.Api.Extensions;
using CRM.Api.Seeding;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddIdentityServices();

builder.Services.AddControllers();

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithAuth();

builder.Services.AddCorsConfig();

var app = builder.Build();

try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var db = scope.ServiceProvider.GetRequiredService<CrmDbContext>();
        db.Database.Migrate();

        if (app.Environment.IsDevelopment())
        {
            await IdentitySeeder.SeedAsync(services);
            await DataSeeder.SeedData(db, services);
        }

    }
}
catch (Exception ex)
{
    Console.WriteLine($"Database Migration Failed: {ex.Message}");
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseCors("FrontendPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();