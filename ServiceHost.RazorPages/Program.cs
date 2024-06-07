using SM.Infrastructure.Configuration;
using DM.Infrastructure.Configuration;
using IM.Infrastructure.Configuration;
using Base_Framework.Configs;
using System.Configuration;
using SiteQuery_Configuration;
using Base_Framework.Configuration;
using BM.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
