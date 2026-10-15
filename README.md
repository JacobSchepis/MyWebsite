# MyWebsite

My personal portfolio site, built with ASP.NET Core Razor Pages and published as a static
site on Azure Static Web Apps. It has Home, About, Projects and Contact pages, with a
responsive CSS grid layout and a mobile menu.

**Live site: <https://www.jacobschepis.com>**

## Built with

C#, ASP.NET Core 8 Razor Pages, HTML, CSS, Bootstrap. Tech icons are from
[Devicon](https://devicon.dev/).

## Running it

Needs the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
dotnet run --launch-profile http
```

Then open <http://localhost:5085>.

## Building the static site

The pages are written as Razor Pages, then rendered to plain HTML for hosting:

```bash
dotnet run --configuration Release --no-launch-profile -- --export dist
```

That writes every page and the assets it uses to `dist/` (see `StaticExport.cs`), ready for
any static host. On every push to `main`, the GitHub Actions workflow in
`.github/workflows/deploy.yml` does this and deploys `dist/` to Azure Static Web Apps. It
needs a repository secret called `AZURE_STATIC_WEB_APPS_API_TOKEN` (the Static Web App's
deployment token), which is set up; without it the workflow only checks the site builds.
The domain is registered at Hostinger, with DNS records there pointing `www` (CNAME) and
the bare domain (ALIAS) at the Static Web App.

## Editing the content

The projects, tech stack, headline and links all live in `Models/Portfolio.cs`; the Home,
About and Projects pages render from it. Project screenshots go in `wwwroot/images/projects/`.
