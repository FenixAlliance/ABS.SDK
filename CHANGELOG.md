# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).
## [1.1.6.x] - 2021-04-22
### Added
- [ABS] Template Views
- [ABS] View Components
- [ABS] Drag 'n Drop Live Editor. (Preview)
## [1.1.5] - 2021-04-21
### Added
- [ABS] View Precompilation
- [ABS] Internal Plugin Support+
- [ABS] Dynamic Portal Metadata
- [ABS] Google Meta Tags Integration
- [ABS] Google Analytics Integration
- [ABS] Google Verification Code Integration
- [ABS] Bing Verification Code Integration
- [ABS] Pinterest Verification Code Integration
- [ABS] Facebook Pixel Verification Code Integration
- [ABS] ICX Taxonomies Creation Blazor Pages.
- [ACL] Store Configuration Objects.
- [APS] External Authentication Provider configuration pages.

### Changed
- [ABP] Fix error while previewing files on File System Explorer.
- [ICX] Fix error where new users got a 500 when visiting the store.
- [ICX] Update Swiper to the latest version.
- [ABS] Monaco editor now lives inside the project instead as an node module.
- [ICX] ICX Static Files audit, bundling & minification.
- [ICX] Fix UI error on cart record addition/deletion.
- [APS] Fix Auth Error: when users not belong to any tenant, they used to got a E500 on nested File Retrieval.
- [ABM] Model Modification to support db-stored precompiled views.
### Removed
- [ICX] Taxonomies Creation Controllers/Views.
## [1.1.4] - 2021-04-13
### Added
- [ABS] Extension Updates Page
- [ABS] Razor Templating Engine
- [APS] Google Authentication
- [APS] Facebook Authentication
- [APS] Microsoft Authentication
- [APS] Twitter Authentication
- [APS] LinkedIn Authentication
- [APS] Instagram Authentication
- [APS] Github Authentication
- [SEO] Zift 123 Analytics Script Integration
- [SEO] Facebook Pixel Integration
- [SEO] Facebook Chat Widget Integration
- [SEO] Google Analytics integration
- [SEO] Google Merchant Center integration
- [SEO] Google Verification Code Integration
- [SEO] Google Tag Manager Integration
- [SEO] Bing Verification code integration
- [SEO] Pinterest verification code integration 
- [SEO] Dynamic Structured Metadata
- [UI] Adds Off-Canvas Cart Slider
- [UI] Dynamic Top Bar content
- [UI] Logo size customization options
- [UI] Footer Dynamic Content
- [UI] Footer/Header Synamic styling


## [1.1.3] - 2021-04-09
### Added
- [ACL] Radzen.Blazor is now a project dependency. 
- [ACL] RabbitMQ.Client is now a project dependency. 
- [ACL] Fluid.Core is now a project dependency. 
- [ACL] FluentValidation is now a project dependency. 
- [ACL] NuGet.Packaging is now a project dependency. 
- [ACL] FluentEmail.Core is now a project dependency. 
- [ACL] Flurl.Http is now a project dependency. 
- [ACL] Standard.Licensing is now a project dependency. 
- [ACL] NodaTime is now a project dependency. 
- [ACL] Serilog is now a project dependency. 
- [ACL] Autofac is now a project dependency. 
- [ACL] CsvHelper is now a project dependency. 
- [ACL] Dapper is now a project dependency. 
- [ACL] AngleSharp is now a project dependency. 
- [ACL] IdentityServer4 is now a project dependency. 
- [ACL] DotLiquid is now a project dependency. 
- [ACL] Emitter is now a project dependency. 
- [ACL] MediatR is now a project dependency. 
- [ACL] SixLabors.ImageSharp.Web is now a project dependency. 
- [ACL] RazorLight is now a project dependency. 
- [ACL] MassTransit is now a project dependency. 
- [ACL] ZXing.Net is now a project dependency. 
- [ACL] Z.EntityFramework.Plus.EFCore is now a project dependency. 

### Changed
- [ABP] Fix error where plugin assembly paths always returned null (IPluginManager Implementation)


## [1.1.2] - 2021-02-23
### Added
- Adds ABP Proxy
- Missing ACL configuration Types
- ABS Extensions Gallery
- ABS Extensions Installer
- ABS Web Installer
- ABS Admin Portal
- Dynamic Web Page/Post creation
- Assembly Explorer
- Roles and Permissions Explorer
- Admin Dashboard Initials
- Added support for SixLabors.ImageSharp.Web
- Forex service data is now scraped by Fenix Alliance.
- Data Services are not coded to a replaceable interface implementation.
- ABS.Hub project now contains everything we need to create a new ABS Instance.
- Added support for IdentityServer4 as a replacement for Alliance Passport Services.
- ACL.Licensing is now a part of the Alliance Business Suite.


### Changed

- Extracts interface for ACL configuration Types
- ACS is now ABP.BotEngine
- Plugin Manager is now losely coupled to IPluginManager
- Adds File Manager and FileSystem Service
- Adds antivirus scanning extension for FileSystem Service (Windows Defender)
- AccountHolder is now the standard identity class.
- Fix minor UI glitches and broken links.
- Fix several bugs on application startup and related extensions.

### Removed
- Data Helpers marked for deprecation.
- ABS.Nucleus was deprecated and is no longer a part of this project.

## [1.1.1] - 2021-01-20
### Added
- Adds ABP Proxy
- Adds Infinity Comex Support
- Missing ACL configuration Types

### Changed
- Fix Namespaces
- ABS.Portal.Paperbits is now ABS.Portal.Editor
- Adds ABS.Portal.UI Components (20+ View Components)

### Removed


## [1.1.0] - 2021-01-12
### Added
- Nuget Packages @1.1.0
- Initial Portal Admin Blazor Application at route /admin.

### Changed
- Standarize namespace at v1.1.0

### Removed

## [1.0.0] - 2020-12-31

### Added
- Authentication / User Management / Profile Management
- Authorization / Roles Management / Granular Permissions
- Blazor Support
- Cross Platform Database Support ( MySQL, MSSQL )
- Dynamic CSS/Lazy Loading
- Dynamic Page Compositing Model / Site & Page Management
- Dynamic Routing
- Dynamic Swagger Specs
- EF Core Migrations for Database Installation / Upgrade
- Enabled for Infinity Comex (eCommerce Extension)
- Event Logging / Audit Trail
- Extensibility via Custom Modules
- Extensibility via Custom Themes
- Folder / File Management (Azure Storage, File System)
- GraphQl API with Voyager, GraphiQl y GraphQl Playground
- Headless API with Swagger Support
- HealthCheck Rules with UI Support
- i18n Enabled (Based on GeoAPI and Custom Settings)
- Improved JavaScript reference support
- In-App CLI (Studio Commander)
- Infinity Comex Support (ABS eCommerce Engine)
- JavaScript Lazy Loading
- Modular Architecture
- Multi-Currency Support
- Multi-Portal ( Monolith & Micro-Service Distributed )
- Multi-Tenant ( Shared Database & Isolated Database )
- Notifications / Email Delivery
- Notifications / SMTP Delivery
- Progressive Web Application Support
- Recycle Bin
- REST API with Swagger Support
- Scheduled Flows ( Background Processing )
- Scheduled Jobs ( Background Processing )
- Seamless Upgrade Experience
- Slack integration (OAuth)
- Support For Additional Authentication Providers (OAuth)