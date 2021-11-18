# Swashbuckle

Lib to include Swagger documentation in ASP.NET APIs.

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

### How to use it in API project 

* Install the following NuGet packages into your solution's API project:  
	* [FluentValidation](https://www.nuget.org/packages/FluentValidation/)
	* [Microsoft.OpenApi](https://www.nuget.org/packages/Microsoft.OpenApi/)
	* [Swashbuckle.AspNetCore.Filters](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Filters/)
	* [Swashbuckle.AspNetCore.ReDoc](https://www.nuget.org/packages/Swashbuckle.AspNetCore.ReDoc/)
	* [Swashbuckle.AspNetCore.SwaggerGen](https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerGen/)
	
* You can reference it directly in CSPROJ file:

```
<Project Sdk="Microsoft.NET.Sdk">
   ...
    <ItemGroup>
	    <PackageReference Include="FluentValidation" Version="10.3.4" />
	    <PackageReference Include="Microsoft.OpenApi" Version="1.2.3" />
	    <PackageReference Include="Swashbuckle.AspNetCore.Filters" Version="7.0.2" />
	    <PackageReference Include="Swashbuckle.AspNetCore.ReDoc" Version="6.2.3" />
	    <PackageReference Include="Swashbuckle.AspNetCore.SwaggerGen" Version="6.2.3" />
	  </ItemGroup>
    ...
</Project>
```
* Add using referente into Startup class.
* Add  the service AddSwaggerConfiguration in ConfigureServices.
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
}