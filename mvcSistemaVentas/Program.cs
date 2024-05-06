using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcSistemaVentas.Data;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Data.Repository;
using mvcSistemaVentas.Models;
using mvcSistemaVentas.Inicializador;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL") ?? throw new 
InvalidOperationException("Connection string 'ConexionSQL' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>
    (options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();
//Siembra de datos - Paso 1
builder.Services.AddScoped<IInicializadorBD, InicializadorBD>();
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//Siembra d datos - Paso 2 Metodo que ejecuta la siembra de datos
SiembraDatos();
//
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{Area=Cliente}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
//Funcionalidad metodo SiembraDatos();
void SiembraDatos()
{
    using (var scope = app.Services.CreateScope())
    {
        var inicializadorBD =
            scope.ServiceProvider.GetRequiredService<IInicializadorBD>();
        inicializadorBD.Inicializador();
    }
}
