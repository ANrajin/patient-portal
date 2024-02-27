using PatientPortal.Domain;
using PatientPortal.Web.Models.HomeModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<HomeModel>();
builder.Services.AddScoped<PatientViewModel>();
builder.Services.AddScoped<PatientEditModel>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDomainServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
