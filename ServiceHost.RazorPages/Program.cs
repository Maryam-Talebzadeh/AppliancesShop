using SM.Infrastructure.Configuration;
using DM.Infrastructure.Configuration;
using IM.Infrastructure.Configuration;
using Base_Framework.Configs;
using SiteQuery_Configuration;
using Base_Framework.Configuration;
using BM.Infrastructure.Configuration;
using CM.Infrastructure.Configuration;
using AM.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Base_Framework.Infrastructure.DataAccess;
using ServiceHost.RazorPages.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();

#region ?Fill SiteSetting

var siteSetting= builder.Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();

#endregion

#region CustomConfiguration

SiteManagementBootstrapper.Configure(builder.Services, siteSetting.SqlConfiguration.AppliancesConnectionString);
DiscountManagementBootstrapper.Configure(builder.Services, siteSetting.SqlConfiguration.AppliancesConnectionString);
InventoryManagementBootstrapper.Configure(builder.Services, siteSetting.SqlConfiguration.AppliancesConnectionString);
SiteQueryBootstrapper.Configure(builder.Services, siteSetting.SqlConfiguration.AppliancesConnectionString);
BlogManagementBootstrapper.Configure(builder.Services, siteSetting.SqlConfiguration.AppliancesConnectionString);
BaseFrameworkBootstrapper.Configure(builder.Services);
CommentManagementBootstrapper.Configure(builder.Services, siteSetting.SqlConfiguration.AppliancesConnectionString);
AccountManagementBootstrapper.Configure(builder.Services, siteSetting.SqlConfiguration.AppliancesConnectionString);

#endregion

#region Authentication

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
               {
                   o.LoginPath = new PathString("/Account");
                   o.LogoutPath = new PathString("/Account");
                   o.AccessDeniedPath = new PathString("/AccessDenied");
               });

#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea",
        builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));

    options.AddPolicy("Shop",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Discount",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));

    options.AddPolicy("Account",
        builder => builder.RequireRole(new List<string> { Roles.Administrator }));
});

builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
                });


#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
