# MyWebsite

My personal portfolio site, built with ASP.NET Core Razor Pages. It has Home, About, Projects
and Contact pages, with a responsive CSS grid layout and a mobile menu.

## Built with

C#, ASP.NET Core 8 Razor Pages, HTML, CSS, Bootstrap. Tech icons are from
[Devicon](https://devicon.dev/).

## Running it

Needs the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
dotnet run --launch-profile http
```

Then open <http://localhost:5085>.

## Editing the content

The projects, tech stack, headline and links all live in `Models/Portfolio.cs`; the Home,
About and Projects pages render from it. Project screenshots go in `wwwroot/images/projects/`.
