// Add Migrations
$ dotnet ef migrations add Initial -c ApplicationDbContext -p Geodata.WebApi -s Geodata.WebApi -o Data/Migrations -v

// Update Database
$ dotnet ef database update -c ApplicationDbContext -p Geodata.WebApi -s Geodata.WebApi -v

// Remove latest migrations
$ dotnet ef migrations remove -c ApplicationDbContext  -p Geodata.WebApi -s Geodata.WebApi -v

// revert
dotnet ef database update InitialResto -p Geodata.WebApi -s Geodata.WebApi -v