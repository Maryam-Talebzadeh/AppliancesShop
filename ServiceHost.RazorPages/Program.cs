using SM.Infrastructure.Configuration;
using DM.Infrastructure.Configuration;
using IM.Infrastructure.Configuration;
using Base_Framework.Configs;
using System.Configuration;
using SiteQuery_Configuration;
using Base_Framework.Configuration;
using BM.Infrastructure.Configuration;
using CM.Infrastructure.Configuration;
using AM.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

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
