

Mitt projekt i Clean Architecture. Det är ett enkelt Web API för en webbshop.

## Vad projektet gör

API:et fixar CRUD för produkter och kategorier. Det går att skapa, hämta, uppdatera och ta bort grejer. Varje produkt är kopplad till en kategori med en vanlig 1-till-många relation.

## Arkitektur

Jag har delat upp projektet i fyra lager enligt Clean Architecture:

- **CleanShop.Domain** – Innehåller entiteter (Product, Category) och interfaces för repos.
- **CleanShop.Application** – Här ligger CQRS-logiken med MediatR (Commands och Queries).
- **CleanShop.Infrastructure** – Databasen (DbContext, repositories och migrations).
- **CleanShop.API** – Controllers, Program.cs och Swagger-inställningar.

Alla beroenden pekar inåt mot Domain-lagret.

## Tekniker som används

- ASP.NET Core 8 Web API
- EF Core + SQL Server (LocalDB)
- MediatR (CQRS)
- Repository Pattern
- Swagger UI

## Hur man startar det

1. Klona repot.
2. Öppna lösningen i Visual Studio.
3. Sätt `CleanShop.API` som startup project.
4. Kör `Update-Database` i Package Manager Console (välj Infrastructure som projekt) för att fixa databasen.
5. Tryck F5 för att köra. Swagger öppnas på `/swagger`.

## Endpoints

**Products**
- GET `/api/Products`
- GET `/api/Products/{id}`
- POST `/api/Products`
- PUT `/api/Products/{id}`
- DELETE `/api/Products/{id}`

**Categories**
- GET `/api/Categories`
- GET `/api/Categories/{id}`
- POST `/api/Categories`