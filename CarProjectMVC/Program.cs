using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.JWT;
using CarProjectMVC.Services.Authenticate;
using CarProjectMVC.Services.Request;
using CarProjectMVC.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(connection);
    options.EnableSensitiveDataLogging();
});

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddUserManager<UserManager<User>>()
    .AddSignInManager<SignInManager<User>>();

builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options =>
          {
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
          });
builder.Services.AddSession();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = AuthOptions.Issuer,
        ValidAudience = AuthOptions.Audience,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = false,
    };
});
builder.Services.AddAuthorization(opts =>
{
    //opts.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
    //                .RequireAuthenticatedUser()
    //                .Build();
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
app.UseSession();
app.Use(async (context, next) =>
{
    string? jwtTokenCookie = context.Request.Cookies["Authorization"];

    if (!jwtTokenCookie.IsNullOrEmpty())
    {
        string[] cookieParams = jwtTokenCookie.Split(";");
        string jwtToken = cookieParams[0];
        context.Request.Headers.Add("Authorization", jwtToken);
    }

    await next();
});
app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
