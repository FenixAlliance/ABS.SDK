# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


## [1.4.1] - 2022-05-12

### Added
- [ABM] ICmsDataService.
- [ABM] ICrmDataService.
- [ABM] ISocialDataService.
- [ABM] IMarketplaceDataService.
- [ABM] ISecurityDataService.
- [ABM] IGlobalDataService.
- [ABM] IForexDataService.
- [ABS] CodeEditorComponent with Monaco Editor.

### Fixed
- [ABS] Fixed Workflows Studio Designer not displaying on production.
- [ABM] Improve IPricingService implementations to always use the latest data to perform generic/historical/extensible/customizable multi-currency amount calculations.

### Changed
- [ACL] Update dependencies to the latest stable versions.
- [ABS] Templating Engine now relies on interface services on the Alliance Business Model.
- [ABS] Templating Engine now relies on default service implementations on the Alliance Business Model.
- [ABS] PortalContext is now optimized to use DataServices.
- [ABS] StudioContext is now more efficient through PortalContext Optimization.
- [ABS] `Studio.Core` now contains the layout, components, and utilities for the ABS Studio.
- [ABS] Academy Portal is now an independent dll compatible with `Studio.Core`.
- [ABS] Admin Portal is now an independent dll compatible with `Studio.Core`.
- [ABS] Wallet Portal is now an independent dll compatible with `Studio.Core`.
- [ABS] Holders Portal is now an independent dll compatible with `Studio.Core`.
- [ABS] Tenants Portal is now an independent dll compatible with `Studio.Core`.
- [ABS] Social Network is now an independent dll compatible with `Studio.Core.`
- [ABS] Support Portal is now an independent dll compatible with `Studio.Core`.
- [ABS] Developer Portal is now an independent dll compatible with `Studio.Core`.

### Removed
- [ABM] I 

## [1.4.0] - 2022-01-12

### Added

- [ACL] .NET 6.0 Support.
- [ABS] In-Studio Cart.
- [ABS] In-Studio Store.
- [ABS] In-Studio Wallet.
- [ABS] In-Studio Academy.
- [ABS] In-Studio Networks.
- [ABS] In-Studio JobBoard.
- [ABS] Lead Form Component.
- [ABS] Newsletter Form Component.
- [ABS] Create Business Modal Form.
- [ABS] Email Template Editor Pages.
- [ABS] Token Management Options Page.
- [ABS] Stock Items Categorizer.
- [APS] EN-US, ES-CO Localizations.
- [APS] Account Mgmt. Email Alerts.
- [APS] Google ReCaptcha Service.
- [APS] Certificates Manager Service.
- [APS] OAuth & IODC Service Support.
- [ABS] Social Feeds & Post Reactions Bar.
- [ABS] PortalContext Country Selector Form.
- [ABS] PortalContext Currency Selector Form.
- [ABS] PortalContext Language Selector Form.
- [ABS] Monaco Editor Component for WebContent.
- [ABM] AccountHolder Birthday & Gender Properties
- [ABM] IPortalContext Interface and default implementation (PortalContext Class)
- [ABM] ISocialDataService Interface and default implementation (SocialDataService Class)
- [ABM] IAssembliesService Interface and default implementation (AssembliesService Class)
- [ABM] IPaymentsService Interface and default implementation (BankTransferPaymentsService Class)
- [ABM] IStorageService Interface & implementation (FileSystemStorageService, AzureStorageStorageService & AwsS3StorageService Classes)

### Changed
- [ACL] Updated Dependencies to the latest version
- [ABM] Improved Queries
- [ABM] Improved MarketplaceData
- [ABM] Improved Memory Allocation
- [ABS] Studio Dashboard Icons.

### Removed
- [ACL] Remove deprecated dependencies

### Fixed
- [ABS] Portal & Tenant Selector.
- [ICX] Duplicated Recently Viewed Product Records.
- [ABS] Fix Invoice Outliner Glitch.
- [ABS] Fix Web Installer Versioning Glitch.
- [ABS] Fix FHIR Server Pooling Glitch.
- [ABS] Fix Portal Domain Bindings.
- [ABS] Fix Network Dashboard Deadlock on IP Verification.

## [1.3.0] - 2021-07-12

### Added
- [ABM] Oracle Database Provider.
- [ABM] IOptionsService Interface and default implementation (OptionsService)

### Changed
- [ACL] Updated Dependencies to the latest version.

### Removed
- [ACL] Remove deprecated dependencies.

### Fixed
- [ABS] Fix Workflows Data Provider (LiteSQL)
- [ABM] Entities Disambiguation


## [1.2.1] - 2021-07-13 
### Added
- [ABS] View Rendering Cache
- [ABS] AppDomain Assembly Scoping


## [1.2] - 2021-07-12
### Added
- [ABS] Razor Templating Engine
- [ABS] Custom Options Manager (API)
- [ABS] Portal Option Manager (UI)
- [ABS] Custom Portal Option Definitions
- [ABS] Virtual SPA Support (Angular/React)
- [ABS] Custom Service Endpoint Definitions

## [1.1.9] - 2021-06-30
### Added
- [ABS] Theme Precompilation

## [1.1.8] - 2021-06-18

### Added
- [ABS] Workflows Capability


## [1.1.7] - 2021-06-06
### Added
- [ABS] Log Viewer
- [ABS] Template Views
- [ABS] View Components
- [ABS] Blog Post Editor
- [ABS] Drag 'n Drop Live Editor. (Preview)
- [ABS] Support for Angular and React+Redux SPAs
- [ABS] Initial Web Content (Editable Pages, Components & Templates)
- [ABS] Internal Web Content (Sys locked Pages, Components & Templates)
- [ABS] Frontend Admin Bar
- [ABS] Invoice Outliner
- [ABS] Invoice Manager
- [ABM] Marketing Module Models
- [ABS] Project Service Models
- [ABM] LMS Service Models
- [ABS] Add support for Bootstrap CSS
- [ABS] Add support for Foundation CSS
- [ABS] Adds support for Fabric JS and Fluent UI.
- [ABS] Ensure non-existence of viral licensed libraries. (e.g GNU)
- [ABS] Adds IViewBuffer, Resx, and Model Resolver to Templating Engine
- [ABS] Adds Localization String Manager. Initial Localization Capabilities.

### Changed
- [ABS] Fix HTTP context access on IIS making the installation process fail.
- [ABS] Fix HTTP context access on IIS when trying to create a new view.
- [ABS] Fix HTTP context access on IIS when trying to edit a new view.
- [ABS] Fix HTTP context access on IIS when trying to create a new post.
- [ABS] Fix HTTP context access on IIS when trying to edit a new post.
- [ABM] Fiscalization document Models
- [ABM] Project Service document Models
- [ABM] Pricing engine Models
- [ABM] Workflow engine Models
- [ABM] Web Content Records now share a single base class
- [ABM] ItemPriceList is now a PriceListRecord.
- [ABS] Fix error when referencing scripts into a Web Content being malformed by templating engine.
- [ABS] Fix page tree navigation on the live editor.


## [1.1.6] - 2021-04-21
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
- [ABS] Monaco editor now lives inside the project instead of as a node module.
- [ICX] ICX Static Files audit, bundling & minification.
- [ICX] Fix UI error on cart record addition/deletion.
- [APS] Fix Auth Error: when users do not belong to any tenant, they used to get an E500 on nested File Retrieval.
- [ABM] Model Modification to support DB-stored precompiled views.
### Removed
- [ICX] Taxonomies Creation Controllers/Views.

## [1.1.4.x] - 2021-04-13
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
- [UI] Footer/Header Dynamic styling


## [1.1.3.x] - 2021-04-09
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


## [1.1.2.x] - 2021-02-23
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
- Data Services are not coded to replaceable interface implementation.
- ABS.Hub project now contains everything we need to create a new ABS Instance.
- Added support for IdentityServer4 as a replacement for Alliance Passport Services.
- ACL.Licensing is now a part of the Alliance Business Suite.


### Changed

- Extracts interface for ACL configuration Types
- ACS is now ABP.BotEngine
- Plugin Manager is now loosely coupled to IPluginManager
- Adds File Manager and FileSystem Service
- Adds antivirus scanning extension for FileSystem Service (Windows Defender)
- AccountHolder is now the standard identity class.
- Fix minor UI glitches and broken links.
- Fix several bugs on application startup and related extensions.

### Removed
- Data Helpers marked for deprecation.
- ABS.Nucleus was deprecated and is no longer a part of this project.

## [1.1.1.x] - 2021-01-20
### Added
- Adds ABP Proxy
- Adds Infinity Comex Support
- Missing ACL configuration Types

### Changed
- Fix Namespaces
- ABS.Portal.Paperbits is now ABS.Portal.Editor
- Adds ABS.Portal.UI Components (20+ View Components)

### Removed


## [1.1.0.x] - 2021-01-12
### Added
- Nuget Packages @1.1.0
- Initial Portal Admin Blazor Application at route /admin.

### Changed
- Standardize namespace at v1.1.0

### Removed

## [1.0.0.x] - 2020-12-31

### Added
- Authentication / User Management / Profile Management
- Authorization / Roles Management / Granular Permissions
- Blazor Support
- Cross-Platform Database Support ( MySQL, MSSQL )
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
- graphql API with Voyager, GraphiQl y GraphQl Playground
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