# dotnet-eshop

dotnet new sln -n eshop

dotnet new web -n name

dotnet sln eshop.slnx add src/Services/Catalog/Catalog.API/Catalog.API.csproj

sudo systemctl stop postgresql



dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update

//for removing
dotnet ef database update 0
dotnet ef migrations remove
