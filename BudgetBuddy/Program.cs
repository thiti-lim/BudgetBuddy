using BudgetBuddy.Data;
using BudgetBuddy.Repositories;
using BudgetBuddy.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using MudBlazor.Services;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
	.AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddControllersWithViews()
	.AddMicrosoftIdentityUI();

//builder.Services.AddSignalR().AddAzureSignalR(options => options.ServerStickyMode = Microsoft.Azure.SignalR.ServerStickyMode.Required);
builder.Services.AddAuthorization();

//builder.Services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("Default"))); 
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
	.AddMicrosoftIdentityConsentHandler();
builder.Services.AddMudServices();


builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
