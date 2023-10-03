using CarProjectMVC.Context;
using CarProjectMVC.Services.Authenticate;
using CarProjectMVC.Services.Request;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(connection);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options =>
          {
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
          });
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
{
    options.Cookie.Name = "CarCookieMiddlewareInstance";
    options.LoginPath = "/Login/Index";
    options.AccessDeniedPath = "/AccessDenied/Index";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});
builder.Services.AddAuthorization(opts =>
{

    opts.AddPolicy("Create", policy =>
    {
        policy.RequireClaim("CanCreate", "True");
    });
    opts.AddPolicy("Read", policy =>
    {
        policy.RequireClaim("CanRead", "True");
    });
    opts.AddPolicy("Update", policy =>
    {
        policy.RequireClaim("CanUpdate", "True");
    });
    opts.AddPolicy("Delete", policy =>
    {
        policy.RequireClaim("CanDelete", "True");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

//app.UseCors(builder => builder.AllowAnyOrigin());
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
