Set ProjectName=%1
Set AppName=%2


if "%ProjectName%" == "" Set ProjectName=NewProject

if "%AppName%" == "" Set AppName=App

mkdir "%ProjectName%"
cd "%ProjectName%"

dotnet new globaljson --sdk-version 6.0.408

dotnet new gitignore

dotnet new sln -n %AppName%

dotnet new classlib -o %AppName%.Domain
dotnet new classlib -o %AppName%.Application
dotnet new classlib -o %AppName%.Infra.Data
dotnet new classlib -o %AppName%.Infra.IoC
dotnet new xunit -o %AppName%.Domain.Tests
dotnet new mvc -o %AppName%.WebAdmin
dotnet new mvc -o %AppName%.WebUI
dotnet new webapi -o %AppName%.WebApi

dotnet sln %AppName%.sln add .\%AppName%.Domain\%AppName%.Domain.csproj
dotnet sln %AppName%.sln add .\%AppName%.Application\%AppName%.Application.csproj
dotnet sln %AppName%.sln add .\%AppName%.Infra.Data\%AppName%.Infra.Data.csproj
dotnet sln %AppName%.sln add .\%AppName%.Infra.IoC\%AppName%.Infra.IoC.csproj
dotnet sln %AppName%.sln add .\%AppName%.WebAdmin\%AppName%.WebAdmin.csproj
dotnet sln %AppName%.sln add .\%AppName%.WebUI\%AppName%.WebUI.csproj
dotnet sln %AppName%.sln add .\%AppName%.WebApi\%AppName%.WebApi.csproj
dotnet sln %AppName%.sln add .\%AppName%.Domain.Tests\%AppName%.Domain.Tests.csproj

dotnet add .\%AppName%.Application\%AppName%.Application.csproj reference .\%AppName%.Domain\%AppName%.Domain.csproj
dotnet add .\%AppName%.Infra.Data\%AppName%.Infra.Data.csproj reference .\%AppName%.Domain\%AppName%.Domain.csproj
dotnet add .\%AppName%.Infra.IoC\%AppName%.Infra.IoC.csproj reference .\%AppName%.Domain\%AppName%.Domain.csproj
dotnet add .\%AppName%.Infra.IoC\%AppName%.Infra.IoC.csproj reference .\%AppName%.Application\%AppName%.Application.csproj
dotnet add .\%AppName%.Infra.IoC\%AppName%.Infra.IoC.csproj reference .\%AppName%.Infra.Data\%AppName%.Infra.Data.csproj
dotnet add .\%AppName%.WebAdmin\%AppName%.WebAdmin.csproj reference .\%AppName%.Infra.IoC\%AppName%.Infra.IoC.csproj
dotnet add .\%AppName%.WebUI\%AppName%.WebUI.csproj reference .\%AppName%.Infra.IoC\%AppName%.Infra.IoC.csproj
dotnet add .\%AppName%.WebApi\%AppName%.WebApi.csproj reference .\%AppName%.Infra.IoC\%AppName%.Infra.IoC.csproj
dotnet add .\%AppName%.Domain.Tests\%AppName%.Domain.Tests.csproj reference .\%AppName%.Domain\%AppName%.Domain.csproj

cd %AppName%.Domain
mkdir Account
mkdir Entities
mkdir Interfaces
mkdir Validation
del "Class1.cs"
cd ..

cd %AppName%.Application
mkdir DTOs
mkdir Interfaces
mkdir Mappings
mkdir Services
dotnet add package AutoMapper --version 12.0.1
dotnet add package FluentValidation --version 11.6.0
del "Class1.cs"
cd ..

cd %AppName%.Infra.Data
mkdir Context
mkdir EntitiesConfiguration
mkdir Identity
mkdir Repositories
dotnet add package Microsoft.AspNetCore.Identity --version 2.2.0
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 6.0.14
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.14
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.14
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.14
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 6.0.2
del "Class1.cs"
cd ..

cd %AppName%.Infra.IoC
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
del "Class1.cs"
cd ..
cd %AppName%.Domain.Tests
del "UnitTest1.cs"
cd ..


code .

REM to run use this comand on terminal. Don't forget to change %AppName% to your project name and %StartAppName% to your Start Project Name.
REM dotnet watch run --project .\%AppName%.%StartAppName%\%AppName%.%StartAppName%.csproj


