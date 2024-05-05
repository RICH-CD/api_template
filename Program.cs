using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using rm_api.Application.Domain.Sucursales;
using rm_api.Application.Interface.Sucursales;
using rm_api.Infrastructure;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("rmConnection");
builder.Services.AddDbContext<rm_devContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // Resolve services
    var context = services.GetRequiredService<rm_devContext>();
    //context.Database.Migrate();

    // Use services
    // Example: clientesDireccionesService.addSucursalesClientes();

    // Other application logic
}

app.Run();