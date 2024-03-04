using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using TaskMaster.Application.ServiceConfiguration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddRazorPages();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 2; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseNotyf();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
