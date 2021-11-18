# Swashbuckle

Lib to include Swagger documentation in ASP.NET APIs and apply filters in properties when to open api documentation.

## Development

The project uses the .NET Standard 2.0 for packages and uses the [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) for testing.

### Restore and build packages
``` shell
dotnet build
```

### Run the tests
``` shell
dotnet test
```

## Features

### Attributes

``` C#
[SwaggerExclude]
public string MyProperty { get; set; }
```
`[SwaggerExclude]` - The decorator is responsible for ignoring property to open api documentation.	
``` C#
[SwaggerMaxLength(100)]
public string MyProperty { get; set; }
```
`[SwaggerMaxLength(MaxLength)]` - The decorator is responsible for setting max length in property to open api documentation.
``` C#
[SwaggerRequired]
public string MyProperty { get; set; }
```
`[SwaggerRequired]` - The decorator is responsible for setting value required property to open api documentation

## How to use in project 

* Install the following NuGet packages into your solution's project:  
	* [JSM.Swashbuckle.AspNetCore.Swagger](https://www.nuget.org/packages/JSM.Swashbuckle.AspNetCore.Swagger/)
	
* You can reference it directly in CSPROJ file:

```
<Project Sdk="Microsoft.NET.Sdk">
   ...
    <ItemGroup>
	    <PackageReference Include="JSM.Swashbuckle.AspNetCore.Swagger" Version="1.0.0" />
	  </ItemGroup>
    ...
</Project>
```

## How to use in API project 

With the lib it is possible to configure Swagger in the API project registering the service and configuring the pipeline.
The feature is implemented by extending the contract to a collection of service descriptors (IServiceCollection) and the class that provides the mechanisms to configure an application's request pipeline (IApplicationBuilder).
Implementation example in project API Startup.cs: 

* Add using referente into Startup class.
* Add the service AddSwaggerConfiguration in ConfigureServices.
* Configure the pipeline with UseSwaggerConfiguration in Configure.
* Build your solution. 

```C#
using JSM.Swashbuckle.AspNetCore.Swagger.Configurations;

public class Startup
{
     public Startup(IConfiguration configuration, IWebHostEnvironment env)
     {
         Configuration = configuration;
         _env = env;
     }

     public IConfiguration Configuration { get; }
     private readonly IWebHostEnvironment _env;

     public virtual void ConfigureServices(IServiceCollection services)
     {
         // Swagger
         services.AddSwaggerConfiguration(Configuration);
     }
	 
	 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
     {
         // Swagger
         app.UseSwaggerConfiguration(Configuration);
     }
}
```