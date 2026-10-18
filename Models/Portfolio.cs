namespace MyWebsite.Models;

/// <summary>A technology badge: a label, plus an icon if one exists.</summary>
public record Tech(string Name, string? Icon = null);

public record Project(
    string Slug,
    string Title,
    string Summary,
    string Description,
    IReadOnlyList<Tech> Stack,
    string? GitHubUrl,
    string? Image = null,
    string? ImageAlt = null,
    string? LiveUrl = null,
    bool InProgress = false,
    string LiveLabel = "Live demo")
{
    /// <summary>Where the project's tile links: the code if it's public, otherwise the live site.</summary>
    public string? PrimaryUrl => GitHubUrl ?? LiveUrl;
}

public enum CertStatus { Earned, InProgress, Planned }

/// <summary>A Microsoft certification, e.g. Name "Azure Fundamentals", Code "AZ-900".</summary>
public record Certification(string Name, string Code, CertStatus Status);

/// <summary>
/// All the site's content in one place, shared by the Home, About and Projects pages.
/// Icons are from Devicon (MIT), served from jsDelivr.
/// </summary>
public static class Portfolio
{
    private const string Devicon = "https://cdn.jsdelivr.net/npm/devicon@2.16.0/icons";

    public const string Name = "Jacob Schepis";
    public const string Headline = "Software Engineering student (Macquarie University, starting 2027) · C# / .NET developer · Sydney";
    public const string GitHubUrl = "https://github.com/JacobSchepis";
    public const string LinkedInUrl = "https://linkedin.com/in/jacob-schepis";

    public static class Techs
    {
        public static readonly Tech CSharp = new("C#", $"{Devicon}/csharp/csharp-original.svg");
        public static readonly Tech DotNet = new(".NET", $"{Devicon}/dotnetcore/dotnetcore-original.svg");
        public static readonly Tech Blazor = new("Blazor", $"{Devicon}/blazor/blazor-original.svg");
        public static readonly Tech Angular = new("Angular", $"{Devicon}/angular/angular-original.svg");
        public static readonly Tech TypeScript = new("TypeScript", $"{Devicon}/typescript/typescript-original.svg");
        public static readonly Tech SqlServer = new("SQL Server", $"{Devicon}/microsoftsqlserver/microsoftsqlserver-original.svg");
        public static readonly Tech AzureFunctions = new("Azure Functions");
        public static readonly Tech Sql = new("SQL", $"{Devicon}/azuresqldatabase/azuresqldatabase-original.svg");
        public static readonly Tech Sqlite = new("SQLite", $"{Devicon}/sqlite/sqlite-original.svg");
        public static readonly Tech Azure = new("Azure", $"{Devicon}/azure/azure-original.svg");
        public static readonly Tech Git = new("Git", $"{Devicon}/git/git-original.svg");
        public static readonly Tech Cpp = new("C++", $"{Devicon}/cplusplus/cplusplus-original.svg");
        public static readonly Tech OpenGL = new("OpenGL", $"{Devicon}/opengl/opengl-original.svg");
        public static readonly Tech WebSockets = new("WebSockets");
        public static readonly Tech Llm = new("LLM integration");
        public static readonly Tech RestApi = new("REST API");
        public static readonly Tech WinForms = new("WinForms");
        public static readonly Tech Json = new("JSON");
    }

    /// <summary>The stack shown on the Home and About pages.</summary>
    public static readonly IReadOnlyList<Tech> Stack =
    [
        Techs.CSharp, Techs.DotNet, Techs.Blazor, Techs.Angular, Techs.Sql, Techs.Azure, Techs.Git, Techs.Cpp, Techs.OpenGL,
    ];

    /// <summary>Certifications, in the order they're shown.</summary>
    public static readonly IReadOnlyList<Certification> Certifications =
    [
        new("Azure Fundamentals", "AZ-900", CertStatus.Earned),
        new("Azure Administrator Associate", "AZ-104", CertStatus.InProgress),
        new("Azure Solutions Architect Expert", "AZ-305", CertStatus.Planned),
    ];

    /// <summary>Main projects, best first.</summary>
    public static readonly IReadOnlyList<Project> Projects =
    [
        new(
            Slug: "workshop-dashboard",
            Title: "Workshop Dashboard",
            Summary: "Operations dashboard for a medical-equipment repair workshop.",
            Description: "Job queues, LLM-powered quote extraction, courier tracking and customer emails for a medical-equipment repair workshop. Blazor Server on .NET 8 with 440+ tests, and a live demo on Azure.",
            Stack: [Techs.CSharp, Techs.Blazor, Techs.DotNet, Techs.Azure, Techs.Llm],
            GitHubUrl: "https://github.com/JacobSchepis/WorkshopDashboard",
            Image: "/images/projects/workshop-dashboard.png",
            ImageAlt: "The Workshop Dashboard overview page: open workshop jobs grouped by status, with overdue counts",
            LiveUrl: "https://workshop-dashboard-demo-hyeafweeccecfac5.australiaeast-01.azurewebsites.net"),
        new(
            Slug: "central-coast-power",
            Title: "Central Coast Power",
            Summary: "Live website for a family electrical contracting business.",
            Description: "The website for my dad's electrical contracting business: an Angular site covering services, service areas and a quote form, with a C# Azure Functions API that emails enquiries through Resend. Hosted on Azure Static Web Apps with a custom domain and deployed from GitHub Actions.",
            Stack: [Techs.Angular, Techs.CSharp, Techs.AzureFunctions, Techs.Azure],
            GitHubUrl: null,
            Image: "/images/projects/central-coast-power.jpg",
            ImageAlt: "The Central Coast Power home page: \"Reliable electrical work, done right the first time\", with call and free-quote buttons",
            LiveUrl: "https://www.centralcoastpower.com.au",
            LiveLabel: "Visit site"),
        new(
            Slug: "packcracker",
            Title: "PackCracker",
            Summary: "Open Magic: The Gathering booster packs built from real collation data.",
            Description: "Open Magic: The Gathering booster packs for free, built from each set's real collation data (MTGJSON), with a tear-open animation, card-by-card reveal and a saved collection with market values. An Angular app in front of a C# Azure Functions API with EF Core on SQL Server, JWT sign-in and 76 automated tests.",
            Stack: [Techs.Angular, Techs.TypeScript, Techs.CSharp, Techs.AzureFunctions, Techs.SqlServer],
            GitHubUrl: null,
            Image: "/images/projects/packcracker.jpg",
            ImageAlt: "PackCracker's grid view of an opened Duskmourn Collector Booster, with each card's price and the most valuable card badged \"Best pull\""),
        new(
            Slug: "opengl-engine",
            Title: "OpenGL Graphics Engine",
            Summary: "3D engine in C++ and OpenGL. Lead developer; full marks.",
            Description: "A 3D engine in C++ and OpenGL with an entity-component system, PBR materials, shadow mapping, a day/night cycle and procedural clouds. A uni project where I was lead developer; it got full marks.",
            Stack: [Techs.Cpp, Techs.OpenGL],
            GitHubUrl: "https://github.com/JacobSchepis/OpenGL-Graphics-Engine"),
        new(
            Slug: "card-collection",
            Title: "Card Collection App",
            Summary: "Catalogues a Magic: The Gathering collection via the Scryfall API.",
            Description: "A console app for cataloguing a Magic: The Gathering collection, using the Scryfall API and SQLite, with a filter query syntax for searching it.",
            Stack: [Techs.CSharp, Techs.Sqlite, Techs.RestApi],
            GitHubUrl: "https://github.com/JacobSchepis/CardCollectionApp"),
        new(
            Slug: "trivia-game",
            Title: "Trivia Game",
            Summary: "Real-time server for a Jackbox-style party trivia game.",
            Description: "The real-time server for a Jackbox-style party trivia game: WebSocket lobbies and a game-phase state machine.",
            Stack: [Techs.CSharp, Techs.DotNet, Techs.WebSockets],
            GitHubUrl: "https://github.com/JacobSchepis/TriviaGame",
            InProgress: true),
        new(
            Slug: "proxy-card-organiser",
            Title: "Proxy Card Organiser",
            Summary: "Desktop library for Magic: The Gathering proxy card images.",
            Description: "A WinForms app for keeping a library of Magic: The Gathering proxy card images organised: drag an image in to file it under a card name, then search the library and drag images straight out into other programs.",
            Stack: [Techs.CSharp, Techs.WinForms, Techs.Json],
            GitHubUrl: "https://github.com/JacobSchepis/ProxyCardOrganiser"),
        new(
            Slug: "crust-credit",
            Title: "Crust Credit App",
            Summary: "Store-credit tracker for a pizza store.",
            Description: "A WinForms app that replaced a paper list of customer store credit at a pizza store: add credits, then search by name or phone number as you type.",
            Stack: [Techs.CSharp, Techs.WinForms, Techs.Json],
            GitHubUrl: "https://github.com/JacobSchepis/CrustCreditApp"),
    ];
}
