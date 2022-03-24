using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp3.Areas.Identity.Data;
using WebApp3.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WebApp3ContextConnection");
builder.Services.AddDbContext<WebApp3Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<WebApp3User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebApp3Context>();
// Add services to the container.
builder.Services.AddRazorPages();

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

app.MapRazorPages();

app.Run();
