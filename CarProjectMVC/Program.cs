using CarProjectMVC.Areas.Identity.Data;
using CarProjectMVC.Services.Implementations;
using CarProjectMVC.Services.Interfaces;
using CarProjectMVC.Services.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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
        ValidateLifetime = true,
        ValidateIssuerSigningKey = false,
        ClockSkew = TimeSpan.Zero
    };
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
            }

            return Task.CompletedTask;
        }
    };

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
    opts.AddPolicy("Users", policy =>
    {
        policy.RequireClaim("CanManageUsers", "True");
    });
});

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    await next();
});
app.UseSession();
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
