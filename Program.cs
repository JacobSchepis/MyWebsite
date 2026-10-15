using MyWebsite;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

// "--export <folder>" renders the site to static files instead of serving it
var exportIndex = Array.IndexOf(args, "--export");
var exportDir = exportIndex >= 0 ? args.ElementAtOrDefault(exportIndex + 1) ?? "dist" : null;

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (exportDir == null)
{
    app.UseHttpsRedirection();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

if (exportDir != null)
{
    await StaticExport.RunAsync(app, exportDir);
    return;
}

app.Run();
