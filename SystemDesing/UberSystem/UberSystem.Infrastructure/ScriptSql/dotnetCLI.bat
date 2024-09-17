dotnet ef dbcontext scaffold "Data Source=127.0.0.1,1433;Initial Catalog=UberSystemDb;Persist Security Info=True;User ID=sa;Password=Aa@123456;MultipleActiveResultSets=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities 
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7
dotnet add package Microsoft.EntityFrameworkCore --version 7
dotnet tool install --global dotnet-ef --version 7
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7

dotnet add app/app.csproj reference lib/lib.csproj
dotnet new sln --name MySolution
dotnet sln add todo-app/todo-app.csproj
dotnet new classlib -o StringLibrary

dotnet add package Microsoft.AspNetCore.Mvc.Testing
dotnet add package Moq

dotnet new webapp -o  UberSystem.WebApp
dotnet new webapi  -o UberSystem.Api.Authentication
	
EF Core Power Tools