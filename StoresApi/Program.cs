using Microsoft.EntityFrameworkCore;
using StoresApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura la cadena de conexión a la base de datos
builder.Services.AddDbContext<StoresApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Añadir servicios de controladores
builder.Services.AddControllers();

// Añadir Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Este es el paso clave para agregar Swagger

var app = builder.Build();

// Configurar Swagger para que se muestre en el navegador
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Esto habilita la UI de Swagger
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();