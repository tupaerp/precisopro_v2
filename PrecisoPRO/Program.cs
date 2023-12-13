using Microsoft.EntityFrameworkCore;
using PrecisoPRO.Data;
using PrecisoPRO.Helpers;
using PrecisoPRO.Interfaces;
using PrecisoPRO.Repository;
using PrecisoPRO.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEstadoRepository, EstadoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAssociarEmpUf, AssociarEmpUfRepository>();
builder.Services.AddScoped<ICndUf, CndUfRepository>();
builder.Services.AddScoped<INatJuridica, NatJuridicaRepository>();
builder.Services.AddScoped<IRegimeJuridico, RegimeJuridicoRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});



builder.Services.AddScoped<IPhotoService, PhotoService>();



builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));


//Conexão
builder.Services.AddDbContext<PrecisoPRODbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("ConexaoPadrao"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
