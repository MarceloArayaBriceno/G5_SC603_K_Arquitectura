using APS.Data;
using APS.Data.Models;
using APS.Security;
using APS.Web.Architecture;
using APS.Web.Filters;
using APS.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Configura DbContext con SQL Server
builder.Services.AddDbContext<ApdatadbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging() // Para habilitar el logging de datos sensibles
           .LogTo(Console.WriteLine));   // Para enviar los logs a la consola

// Configura Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApdatadbContext>()
    .AddDefaultTokenProviders();

// Configura el inicio de sesi�n
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/AccessDenied";
});

// Agrega Razor Pages
builder.Services.AddRazorPages();  // <-- Esto es clave para Razor Pages

// Agrega controladores con vistas
builder.Services.AddControllersWithViews();

// A�adir Distributed Memory Cache para las sesiones
builder.Services.AddDistributedMemoryCache();

// Configurar y a�adir el servicio de sesi�n
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1); // Cambia el tiempo de expiraci�n de la sesi�n si es necesario
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Registra ISecurityService y SecurityService en el contenedor de servicios
builder.Services.AddScoped<ISecurityService, SecurityService>();

LocalConfiguration.Register(builder.Services);
RepositoryConfiguration.Register(builder.Services);
ServicesConfiguration.Register(builder.Services);

// Construye la aplicaci�n
var app = builder.Build();

// Descargar wkhtmltopdf.exe si no existe
await WkhtmltopdfDownloader.DownloadWkhtmltopdfAsync(); 

// Configura Rotativa
// Aseg�rate de que el archivo wkhtmltopdf.exe est� en wwwroot/Rotativa/
RotativaConfiguration.Setup(app.Environment.WebRootPath, "Rotativa");

// Configura el pipeline de la aplicaci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Usar sesiones en la aplicaci�n
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// Configurar enrutamiento de Razor Pages
app.MapRazorPages();  // <-- Esto es clave para Razor Pages

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
