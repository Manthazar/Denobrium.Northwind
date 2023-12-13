# Denobrium.Northwind
> [!IMPORTANT]
> Northwind Trades and underlying data are pure fiction. Similarities to existing indiciduals and entities are not intended.

Denobrium Northwind is a show-case, a sandbox, conversation opener and incubator for all technical aspects which are typical business use cases. It is based on Microsoft's Northwind data store [sql](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/downloading-sample-databases).

# Scope
Denobrium Northwind aims to represent an entire business application around whatever Northind Trades is trading with. We will touch base on many technologies and demonstrate how they can be embeded into an existing or new application platform. It will have tooling for employees, analysts, operators and a frontend for suppliers to maintain their products.

> [!NOTE]
> Since this is a private illustration, outlined components will appear in the repository over time.

# The Vision 
![platform-overview-draft.png](/Docs/northwind-trades-platform-draft.png)

Out from above vision, the following applications should be called out:
- **Northwind API**: Hosted on premises, it provides an API for held data and supported operative and supplementary processes
- **Northwind Backoffice** v1: A UWP based intranet application serving as a quick prototyping tool for all API functions and visualizations above. We will explore here WinUI3 as well
- Northwind BackOffice v2: Replaces v1 by migrating functions to a modern web app technology such as React.
- Northwind Gateway: Hosted on Azure (Azure Function), it will serve as a proxy to enabled endpoints of the on-premises API.
- Northwind WebShop: A simple webshop for products of Northwind
- Northwind Trades: A simple shop app for products of Northwind made for mobile devices

_Needless to say that we are not aiming for minimal tech stack here. Remember that this repository is also an incubator where we want to see and compare things evolving._

# Component Details
![platform-overview-draft.png](/Docs/northwind-trades-components.png)

## Northwind API
The Northwind API is the heart of the platform. It is represented by one or multiple instances of a REST based API. Whilest the core development is performed in .NET WEBAPI, the core code is done in such a way that it can also run as an Azure Function or Service Fabric service or whatever your .NET liking is. The list of available use cases is [here](/Docs/api-use-cases.md).
The API will switch between data stores, such as Sql Server and Mongodb (respective CosmosDB) based on the need and fit for use.

**Testing** will be done partially on unit level, but will focus on component level. We will also explore integration testing under the umbrella of ms-test. There will be a test-system will allows **short ** triple AAA unit test -regardless of data requirements (this will be achieved by the builder pattern).

## Northwind Backoffice
The Northwind Backoffice is the Swiss Army knife for employees to oversee and operate the companie's core business. It will materialize in a number of ways, starting as a desktop app then evolving to a web app (you may ask for the _why_ ;)).
Since the desktop serves as an exploratory RAD tool, no automated testing will be done here. The production version though should be supported with some test automation framework.

## Northwind Gateway
The Northwind Gateway is the keyhole of Northwind data and action to the public. In the role of proxy it will enable certain activities to be forwarded to the API (the API is not exposed to the public). In this show-case we aim the gateway being hosted on Azure representing a bridge to our (primitive) on-premise server.

## Northwind Webshop
Rather self-explaining. the web shop for customers of Northwind. If Angular would not be a thing, we would likely select an existing web-shop application and integrate it with our own backend.

## Northwind Mobile
The Northwind Mobile will represent the company's web shop in the mobile world. Experience shows that mobile apps may actually be cheaper and reliable (for the customer) than fully responsive web applications. 
