using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace MyWebsite;

/// <summary>
/// Renders every page to plain HTML and copies the assets they use, so the site can be
/// hosted as static files (Azure Static Web Apps).
/// Run with: dotnet run --no-launch-profile -- --export dist
/// </summary>
public static class StaticExport
{
    // Route -> output file, relative to the export folder
    private static readonly (string Route, string File)[] Pages =
    [
        ("/", "index.html"),
        ("/about", "about/index.html"),
        ("/projects", "projects/index.html"),
        ("/contact", "contact/index.html"),
        ("/notfound", "404.html"),
    ];

    // Everything the pages reference from wwwroot; the rest is left out
    private static readonly string[] AssetFolders = ["css", "js", "images"];
    private static readonly string[] AssetFiles = ["favicon.ico", "lib/bootstrap/dist/css/bootstrap.min.css"];

    public static async Task RunAsync(WebApplication app, string outputDir)
    {
        app.Urls.Clear();
        app.Urls.Add("http://127.0.0.1:0");
        await app.StartAsync();

        var address = app.Services.GetRequiredService<IServer>()
            .Features.Get<IServerAddressesFeature>()!.Addresses.First();
        using var http = new HttpClient { BaseAddress = new Uri(address) };

        outputDir = Path.GetFullPath(outputDir);
        if (Directory.Exists(outputDir))
        {
            Directory.Delete(outputDir, recursive: true);
        }

        Console.WriteLine($"Exporting static site to {outputDir}");
        foreach (var (route, file) in Pages)
        {
            var response = await http.GetAsync(route);
            response.EnsureSuccessStatusCode();
            await WriteFileAsync(Path.Combine(outputDir, file), await response.Content.ReadAsByteArrayAsync());
            Console.WriteLine($"  {route} -> {file}");
        }

        var webRoot = app.Environment.WebRootPath;
        foreach (var folder in AssetFolders)
        {
            CopyDirectory(Path.Combine(webRoot, folder), Path.Combine(outputDir, folder));
        }
        foreach (var file in AssetFiles)
        {
            await WriteFileAsync(Path.Combine(outputDir, file), await File.ReadAllBytesAsync(Path.Combine(webRoot, file)));
        }

        // Azure Static Web Apps settings (404 page) live at the root of the deployed site
        File.Copy(Path.Combine(app.Environment.ContentRootPath, "staticwebapp.config.json"),
            Path.Combine(outputDir, "staticwebapp.config.json"));

        await app.StopAsync();
        Console.WriteLine("Done.");
    }

    private static async Task WriteFileAsync(string path, byte[] contents)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        await File.WriteAllBytesAsync(path, contents);
    }

    private static void CopyDirectory(string source, string destination)
    {
        foreach (var file in Directory.EnumerateFiles(source, "*", SearchOption.AllDirectories))
        {
            var target = Path.Combine(destination, Path.GetRelativePath(source, file));
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            File.Copy(file, target);
        }
    }
}
