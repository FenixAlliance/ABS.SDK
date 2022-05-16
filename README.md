![Alliance Business Suite](https://fenixalliance.com.co/ui/images/branding/logo.png "Alliance Business Suite")

<p>
  <a href="https://docs.absuite.net/reference/1.4.0/" target="_blank">
     <img alt="Version" src="https://img.shields.io/badge/Version-1.4.0-blue.svg?cacheSeconds=2592000" />
  </a>
  <a href="https://docs.absuite.net" target="_blank">
    <img alt="Documentation" src="https://img.shields.io/badge/Documentation-yes-brightgreen.svg" />
  </a>
  <a href="http://absuite.net/eula" target="_blank">
    <img alt="License: ABS EULA" src="https://img.shields.io/static/v1?label=License&message=ABS%20EULA&color=blue" />
  </a>
  <a href="https://twitter.com/fenixalliance" target="_blank">
    <img alt="Twitter: fenixalliance" src="https://img.shields.io/twitter/follow/fenixalliance.svg?style=social" />
  </a>
</p>

# Welcome to the Alliance Business Suite Documentation!

Aiming to help organizations reach beyond expectations, the Alliance Business Suite is being designed to augment businesses across industries all over the world through a low-code, and fully customizable business development platform.

At a very high level, the Alliance Business Suite is a set of powerful, extensible, multi-tenant applications built to enable businesses to jumpstart their digitalization process through powerful business applications built to cover the core processes of any given business.

The Alliance Business Suite provides customers with a Full-Stack, Low-Code, Modular, and Multi-Tenant Business Application Framework built on top of the [Alliance Business Platform](https://absuite.net/Suite/Platform). 

The Alliance Business Suite relies on [five major components](/Components.md) designed to separate different functionalities into layers; these components are:

- ## [Alliance Core Libraries](/Components/Alliance-Core-Libraries.md)

The Alliance Core Libraries contain the core abstractions and default implementations required by the Alliance Business Model and dependent components. It is also the external dependency source for the entire Alliance Business Suite, which means that external dependencies, which are dependencies outside the `FenixAlliance.*` namespace, are referenced by the `FenixAlliance.ACL.Deps` Package, which is the base ACL Package and, therefore, it could be referred to as the Core Package.

For more information on the dependency tree, design overview, and external dependencies, please refer to [Advanced Topics](/Advanced.md).

- ## [Alliance Business Model](/Components/Alliance-Business-Model.md)

The Alliance Business Model is a declarative specification and definition of standard entities that represent commonly used concepts and activities across business and productivity applications and is being extended to observational and analytical data as well. ABM provides well-defined, modular, and extensible business entities such as Accounts, Business Units, cases, Contact, Leads, Opportunity, and Items (Products/Services) and interactions with vendors, workers, and customers, such as activities and service level agreements. that serve as the dynamic data layer for the entire Alliance Business Suite.

Anyone can build on and extend ABM definitions to capture additional business-specific scenarios.


- ## [Alliance Passport Service](/Components/Alliance-Passport-Service.md)

The Alliance Passport Service enables developers and non-developers alike 
The Alliance Passport Service is an Authentication/Authorization Engine designed to enable customers to easily configure and manage business identity scenarios by assigning (or connecting) a digital identity to their contacts, whether they are customers, employees, partners, guests, and more. 

It also provides common features for managing authentication, authorization, data protection, HTTPS enforcement, app secrets, XSRF/CSRF prevention, and CORS management. These security features allow you to build robust, yet secure Alliance Business Suite apps.

- ## [Alliance Business Platform](Components/Alliance-Business-Platform.md)

The Alliance Business Platform is a Modular API Framework. It leverages .NET 5.0 with the best of REST, SignalR, GraphQl y gRPCto transact with the Alliance Business Model Schema (AMB). The Alliance Business Platform is an open-source and cross-platform framework for integrating next-generation functionalities into your applications. It allows you to build spectacular single-page apps using .NET and C# with or without JavaScript. ABP apps can connect and transact to the data layer (The Alliance Business Modal Schema) using any language through standard requests through the various GrPC, HTTP, and GraphQL Endpoints. 

You can easily build on, and extend The Alliance Business Platform through ASP.NET + Angular / React (And pretty much any Web Stack Framework), to capture additional business-specific scenarios.

- ## [Alliance Business Studio](/Components/Alliance-Business-Studio.md)

The Alliance Business Studio is the Graphical Administration Engine for the Alliance Business Suite. It allows users to manage their implementations, transact data through the Alliance Business Platform, generate and consume views, and reports, customize and extend the system, and much more.

You can build on top of, and extend The Alliance Business Studio to capture additional business-specific scenarios.

## How to build applications on top of the Alliance Business Suite?

Client and server code are written in C#, allowing users to extend the product with their code through Module libraries. It builds upon next-generation technologies such as Blazor, SignalR, Razor Pages, and MVC through .NET, an open-source and cross-platform framework for building web-mobile apps using C#, with or without the use of JavaScript.

The power of the Alliance Business Suite can be leveraged from small personal blogs, eCommerce platforms, and professional portfolios to the infrastructure of large corporations.

### User Guide
- [Documentation](https://docs.absuite.net)
- [Roadmap](https://dev.azure.com/fenixalliance/ABS.Docs/_workitems/recentlyupdated)

# Getting Started

- Install **[.NET 6 SDK (v6.0.*)](https://dotnet.microsoft.com/download/dotnet/6.0)**.



- Install the latest edition (v16.8 or higher) of [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (Community, Professional, or Enterprise Editions) with the **ASP.NET and web development** workload enabled. Alliance Business Suite works with ALL editions of Visual Studio from Community to Enterprise. If you do not have a SQL Server installation available already and you wish to use LocalDB for development, you must also install the **.NET desktop development workload**.  

- Download a release or Clone the ABS. Portal repository to your local system using Git. Open the **FenixAlliance.ABS.Portal.sln** solution file and Build the solution. Make sure you specify FenixAlliance.ABS.Portal as the Startup Project and then Run the application.


**Installing an official release:**

- A detailed set of instructions for installing Alliance Business Suite on IIS is located here: [Installing Alliance Business Suite on IIS](https://absuite.net/blog/installing-abs-on-iis)
- Instructions for upgrading Alliance Business Suite are located here: [Upgrading Alliance Business Suite ](https://absuite.net/blog/upgrading-abs)

**Additional Instructions**

- If you have already installed a previous version of Alliance Business Suite and you wish to do a clean database install, simply point the DefaultConnection value in the ABS Portal Settings Manager to a fresh database record. This will trigger a re-install when you run the application which will execute the database installation scripts.
   
- Every ABS Repo ignores appsettings.json by default, so as long as you don't delete the directive from .gitignore, you're cleared to submit a pull request. 

**Video Series**

- If you are getting started with Alliance Business Suite, a [series of videos](https://www.youtube.com/playlist?list=PLGYfOT42OgSZdmYctCWeiRkPfGVQbCRWM) are available that explain how to install the product, interact with the user interface, and develop custom modules.

## Documentation
There is a separate [Documentation repository](https://dev.azure.com/fenixalliance/ABS.Docs), which contains various types of documentation for the Alliance Business Suite, including the C# API documentation for every class on every library. The contents of the repository are available at [https://docs.absuite.net](https://docs.absuite.net) as interactive documentation.

---

### Easy Install

The Easy Way: As a Docker Container.

``` PowerShell
docker pull FenixAlliance.ABS:latest
```

### Conventional Install

```PowerShell
git clone https://github.com/FenixAlliance/ABS.Bin
```
```PowerShell
cd ABS.Bin
```
```sh
./FenixAlliance.ABS.Studio.exe
```
or
```sh
dotnet FenixAlliance.ABS.Studio.dll
```

### Installing as an application dependency

- #### Add the Alliance Business Suite Nuget Feed.
``` PowerShell
dotnet nuget add source https://nuget.absuite.net/nuget -n absuite.net
```

- #### Add the NuGet package

```sh
dotnet add package FenixAlliance.ABS.Hub --version latest
```

- #### Register Services and Configuration

```cs
using FenixAlliance.ABS.Hub.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FenixAlliance.ABS
{
    public class Startup
    {
        public IHostEnvironment Environment { get; set; }
        public IConfiguration Configuration { get; }

        // Constructor
        public Startup(IConfiguration Configuration, IHostEnvironment Environment)
        {
            this.Environment = Environment;
            this.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          services.AddAllianceBusinessSuite(Configuration, Environment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
          app.UseAllianceBusinessSuite(Configuration, Environment);
        }
    }
}
```





# Release Announcements

[Alliance Business Suite v1.2](https://absuite.net/Blog/Posts/abs_v1.2)

# Example Screenshots

## ABS Studio Dashboard:

![image.png](/.attachments/image-8bae0adf-518b-4e17-adfe-05bdc9f31fc1.png)

## ABS Extensions:
The ABS is modular. Whether you need to add pages, products, or posts with no code at all (using the ABS Web Designer), modify the style or layout, or add your Types, Controllers, Pages, Views, Components, or Tag Helpers

![ABS Extensions](https://github.com/fenixalliance/abs.docs/blob/master/.attachments/YLVYb8WhDf.gif?raw=true "ABS Extensions")

## ABS Commander Terminal:
The ABS Commander Terminal is a Built-In functionality that allows users to execute commands against the ABP set of APIs.

![ABS Commander Terminal](https://github.com/fenixalliance/abs.docs/blob/master/.attachments/8Jbl76YPxD.gif?raw=true "ABS Commander Terminal")

## ABS WOPI Connector:

The ABS Workplace Module allows users to create, view, and edit Office files with Office for the web, right from their ABS Instances. It also allows users to manage files for pretty much every entity type.

![ABS WOPI Connector](https://github.com/fenixalliance/abs.docs/blob/master/.attachments/E9Or7BZKnX.gif?raw=true "ABS WOPI Connector")

## ACS Bot Maker:

The Alliance Conversational Services Bot Maker Platform is an ABS extension that allows users to create conversational flows using NLP and a graphical UI.

![ABS Bot Maker](https://github.com/fenixalliance/abs.docs/blob/master/.attachments/2id1XVYuYR.gif?raw=true "ABS Bot Maker")


# Versioning

Maintaining forward and backward compatibility is a key goal of the ABS. Therefore, the ABS now uses only additive versioning, which means any revision of the ABM following the "2.0" release will not:

* Introduce new mandatory attributes on previously published entities, or change an optional attribute to be mandatory
* Rename previously published attributes or entities
* Remove previously published attributes

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!<br />Feel free to check [issues page](https://github.com/FenixAlliance/ABM.Models/issues). You can also take a look at the [contributing guide](https://fenixalliance.com.co/technologies/opensource/codeofconduct).

1. [Issue Guidelines](https://github.com/fenixalliance/abs.portal/wiki/Issue-Guidelines)
1. [Report Security Vulnerabilities](https://fenixalliance.com.com/security)
1. [Pull Request Requirements](https://github.com/fenixalliance/ABS/wiki/Contribution-Guidelines)
1. [Translations](https://translate.fenixalliance.com.co)
1. [Chart of Accounts](https://charts.fenixalliance.com.co)

---


## Show your support

Give this project a ⭐️ if this project helped you!


## Author

👤 **Fenix Alliance Inc.**

- Website: https://fenix-alliance.com
- Twitter: [@fenixalliance](https://twitter.com/fenixalliance)
- Github: [@fenixalliance](https://github.com/fenixalliance)
- LinkedIn: <a href="https://www.linkedin.com/company/FenixAlliance/" target="_blank">Fenix Alliance on LinkedIn</a>

## Logo and Trademark

The brand name Alliance Business Suite and its logos are trademarks of Fenix Alliance S.A.S in Colombia and Fenix Alliance Inc in other countries ("Fenix Alliance").

Fenix Alliance owns and oversees the trademarks for the ABS name and logos. We have developed this trademark usage policy with the following goals in mind:

- We’d like to make it easy for anyone to use the ABS name or logo for community-oriented efforts that help spread and improve ABS.
- We’d like to make it clear how ABS-related businesses and projects can (and cannot) use the ABS name and logo.
- We’d like to make it hard for anyone to use the ABS name and logo to unfairly profit from, trick, or confuse people who are looking for official ABS resources.


## Licensing and Contributions

Your access to and use of the Alliance Business Suite's source code is governed by the Fenix Alliance's [End User License Agreement "EULA"](http://absuite.net/eula). If you don't agree to those terms, as amended from time to time, you are not permitted to access or use the Alliance Business Suite.

We welcome any contributions to the Alliance Business Suite development through pull requests on GitHub. Most of our active development is in the development branch, so we prefer to take pull requests there (particularly for new features). We try to make sure that all new code adheres to the Fenix Alliance coding standards. All contributions are governed by the terms of the EULA.


# Legal Notices

Fenix Alliance and any contributors grant you a license to the documentation and other content in this repository under the [Creative Commons Attribution 4.0 International Public License](https://creativecommons.org/licenses/by/4.0/legalcode) and grant you a license to any code or binary form Fenix Alliance through the [ABS EULA](http://absuite.net/eula).

Fenix Alliance, Alliance Business Suite, Infinity Comex, and/or other Fenix Alliance products and services referenced in the documentation may be trademarks or registered trademarks of Fenix Alliance Inc. in the United States/or other countries. The licenses for this project do not grant you rights to use any of Fenix Alliance's names, logos, or trademarks. Fenix Alliance's general trademark guidelines can be found at http://docs.fenix-alliance.com.

Privacy information can be found at https://fenix-alliance.com/legal/policies/privacypolicy

Fenix Alliance and any contributors reserve all other rights, whether under their respective copyrights, patents, or trademarks, whether by implication, estoppel, or otherwise.


<a href="https://www.producthunt.com/posts/alliance-business-suite?utm_source=badge-featured&utm_medium=badge&utm_souce=badge-alliance-business-suite" target="_blank"><img src="https://api.producthunt.com/widgets/embed-image/v1/featured.svg?post_id=300812&theme=dark" alt="Alliance Business Suite - Low-Code Next-Generation Business Development Platform. | Product Hunt" style="width: 250px; height: 54px;" width="250" height="54" /></a>