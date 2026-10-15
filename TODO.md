# MyWebsite: to-do

My personal portfolio site, for job and internship applications. The layout and styling are
done; most of the content is placeholder. Goal: a finished site deployed on Azure and linked
from my GitHub profile and resume.

**Stack:** ASP.NET Core 8 Razor Pages, plain CSS (`wwwroot/css/*.css`, one file per page), Bootstrap.
**Run:** `dotnet run --launch-profile http`, then open http://localhost:5085

## Where it's up to (as of 15 Oct 2026)

All four pages have real content and pass WCAG AA contrast; the layout works down to phone width.
What's left: screenshots for three projects, an optional `mailto:` on Contact, and finishing the
bare-domain DNS (the site is live at https://www.jacobschepis.com).

## Tasks

**Content**

_Oct 2026: all content and fix items below are done, apart from the notes. Project content now
lives in `Models/Portfolio.cs`, shared by every page._

- [x] Home: fill the grid with my name, a one-line headline, tech icons, a short blurb, and tiles for my top projects
- [x] Projects: replace the placeholder cards with my real projects (below), each with a screenshot, short description, tech used and GitHub link
- [ ] Screenshots for OpenGL Graphics Engine, Card Collection App and Trivia Game (they show an icon banner
  for now). Drop images in `wwwroot/images/projects/` and set `Image` / `ImageAlt` in `Models/Portfolio.cs`
- [x] About: make the Tech Stack icons match my real stack (C#, .NET, Blazor, SQL, Azure, Git, C++/OpenGL)
- [x] About: remove the placeholder certification card; link Azure Fundamentals (AZ-900) to my real Microsoft Learn credential, or remove the "View" button
- [x] Delete `wwwroot/pdf/Untitled document.pdf` (it's an example file)
- [x] Replace `placeholder.jpeg` with a real photo, or drop the photo (dropped; Home shows a "JS" monogram)

**Fixes**
- [x] Fix text contrast on About (and check every page passes WCAG AA contrast)
- [x] Contact: replace the broken form with a `mailto:` link plus LinkedIn and GitHub links (simplest), or implement a real handler
  (form replaced with LinkedIn and GitHub cards; add a `mailto:` once there's an address to publish)
- [x] Make the Send / action buttons visible
- [x] Footer: current year and my name instead of "MyWebsite"
- [x] Give each page a proper `<title>` (About currently shows "- MyWebsite")
- [x] Check the layout on a phone-width screen

**Ship it**
- [x] Make the site static so it can use Azure Static Web Apps' free tier, which (unlike free
  App Service) allows a custom domain with free HTTPS (`--export` mode + GitHub Actions workflow)
- [x] Create the Static Web App in Azure (free plan, deployment source "Other") and add its
  deployment token as the `AZURE_STATIC_WEB_APPS_API_TOKEN` repo secret. Live at
  https://www.jacobschepis.com (Azure default URL: https://agreeable-smoke-0cd9f3600.5.azurestaticapps.net)
- [x] www.jacobschepis.com: CNAME at Hostinger, validated in Azure, HTTPS working
- [ ] Bare domain jacobschepis.com: TXT validation record added at Hostinger; still to do: delete the
  parking A record on `@` and add a CNAME on `@` to the azurestaticapps.net host (Hostinger saves it
  as ALIAS), then check https://jacobschepis.com loads
- [ ] Turn on auto-renew for jacobschepis.com in hPanel
- [x] Add the live link to the README
- [x] Add the live link to my resume ("Jacob Schepis – Resume (updated).docx/.pdf" in Downloads)
- [x] Add the live link to the GitHub repo's Website field (and drop "work in progress" from its
  description)
- [ ] Add the live link to my GitHub profile
- [x] Update the README once it's no longer a work in progress

## Content to use

Don't invent details; use these, or ask me.

**Headline:** Software Engineering student (Macquarie University, starting 2027) · C# / .NET developer · Sydney

**Projects, best first:**

| Project | Description | Link |
| --- | --- | --- |
| Workshop Dashboard | Operations dashboard for a medical-equipment repair workshop: job queues, LLM-powered quote extraction, courier tracking and customer emails. Blazor Server on .NET 8 with 440+ tests; live demo on Azure (link in its README) | https://github.com/JacobSchepis/WorkshopDashboard |
| OpenGL Graphics Engine | 3D engine in C++ and OpenGL with an entity-component system, PBR materials, shadow mapping, a day/night cycle and procedural clouds. Uni project; I was lead developer and it got full marks | https://github.com/JacobSchepis/OpenGL-Graphics-Engine |
| Card Collection App | Console app for cataloguing a Magic: The Gathering collection, using the Scryfall API and SQLite, with a filter query syntax | https://github.com/JacobSchepis/CardCollectionApp |
| Trivia Game (in progress) | Real-time server for a Jackbox-style party trivia game: WebSocket lobbies and a game-phase state machine | https://github.com/JacobSchepis/TriviaGame |

Smaller ones, optional: ProxyCardOrganiser (WinForms MTG proxy image library), CrustCreditApp
(WinForms store-credit tracker).

**Certification:** Microsoft Certified: Azure Fundamentals (AZ-900)

**Links:** GitHub https://github.com/JacobSchepis · LinkedIn https://linkedin.com/in/jacob-schepis
