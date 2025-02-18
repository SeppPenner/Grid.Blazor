# Grid.Blazor

A fork from: https://gridmvc.codeplex.com/

It supports .NET Core 3.0 Preview 7

**Important** If you use EF Core 3.0, continue using **EF Core 3.0 Preview5**. 

EF Core 3.0 Preview6 and Preview7 have not implemented all Linq features and many queries throw exceptions: https://devblogs.microsoft.com/dotnet/announcing-entity-framework-core-3-0-preview-6-and-entity-framework-6-3-preview-6/

It is expected that EF Core 3.0 Preview8 will implement all Linq features.

## Demo 
http://gridblazor.azurewebsites.net

## Documentation
Native C# Grid components for:
* [Blazor client-side](./docs/blazor_client/Documentation.md)
* [Blazor server-side](./docs/blazor_server/Documentation.md)
* [ASP.NET Core MVC](./docs/dotnetcore/Documentation.md)

This is an example of a table of items using this component:

![Image of GridBlazor](./docs/images/GridBlazor.png)

