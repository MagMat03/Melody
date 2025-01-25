Aplikacja Muzyczna Melody

Aplikacja webowa do zarządzania piosenkami i playlistami, stworzona w technologii ASP.NET Core z użyciem Entity Framework Core oraz SQL Server.

Funkcjonalności

Przeglądanie listy piosenek.

Szczegóły wybranej piosenki (tytuł, wykonawca, id).

Tworzenie nowych piosenek (tylko dla artystów).

Edycja oraz usuwanie piosenek (tylko przez autora danej piosenki).

Zarządzanie playlistą użytkownika (dodawanie/usuwanie piosenek).

System rejestracji i logowania użytkowników z wykorzystaniem ASP.NET Identity.

Technologia

Backend: ASP.NET Core

Frontend: ASP.NET Razor Pages

Baza danych: SQL Server

ORM: Entity Framework Core

Wymagania systemowe

Środowisko programistyczne: Visual Studio

Framework: .NET 

Baza danych: SQL Server

Inne narzędzia: EF Core Tools

Instalacja

Sklonuj repozytorium: 
git clone https://github.com/MagMat03/Melody.git
cd Melody

Przygotowanie bazy danych:

W pliku appsettings.json skonfiguruj połączenie z bazą danych SQL Server.
Wykonaj migracje bazy danych:

dotnet ef migrations add InitialMigration
dotnet ef database update
Uruchomienie aplikacji:

Uruchom aplikację w Visual Studio lub przez terminal:


dotnet run
Aplikacja powinna być dostępna pod adresem: http://localhost:5000.
