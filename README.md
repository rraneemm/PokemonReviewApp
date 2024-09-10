# Pokémon Review App
Welcome to the Pokémon Review App! This is a guided project aimed at building a full-fledged review platform where users can rate and review various Pokémon. The project includes features such as Pokémon details, categories, owners, reviewers, and reviews management. The app uses **ASP.NET Core** for the backend and integrates with various repositories using the Repository pattern and AutoMapper.

## Table of Contents
[Features](#features)

[Requirements](#requirements)

[Installation](#installation)

[Project Structure](#porject-structure)

[Usage](#usage)

[Contributing](#contributing)

### Features
**Pokémon Management**: View, create, update, and delete Pokémon.

**Category Management**: Organize Pokémon by category.

**Owner Management**: Link Pokémon to their respective owners.

**Review System**: Users can rate and review Pokémon.

**Reviewer Management**: View and be a reviewer. 

**AutoMapper Integration**: Map between DTOs and Models.

**Repository Pattern**: Data access is abstracted into repositories.


### Requirements
Before you start, make sure you have the following installed:
- .NET Core SDK 6.0+
- SQL Server or PostgreSQL
- Entity Framework Core
- AutoMapper
- Swagger (for API testing)
- Postman (optional, for API testing)
### Installation
#### Clone the repository:

```bash
git clone https://github.com/yourusername/pokemon-review-app.git
cd pokemon-review-app
```
#### Install project dependencies:

```bash
dotnet restore
```
#### Update appsettings.json with your database connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=PokemonReviewDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
  }
}
```
#### Apply database migrations:

```bash
dotnet ef database update```
#### Run the application:

```bash
dotnet run
```
#### Navigate to [http://localhost:3000/swagger](http://localhost:3000/swagger) to explore the API documentation.

### Project Structure
```
PokemonReviewApp/
│
├── Controllers/
│   ├── PokemonController.cs
│   ├── CategoryController.cs
│   ├── OwnerController.cs
│   └── ReviewController.cs
│   └── ReviewerController.cs
│
├── Dtos/
│   ├── PokemonDto.cs
│   ├── CategoryDto.cs
│   ├── OwnerDto.cs
│   └── ReviewDto.cs
│   └── ReviewerDto.cs
│
├── Interfaces/
│   ├── IPokemonRepository.cs
│   ├── ICategoryRepository.cs
│   ├── IOwnerRepository.cs
│   └── IReviewRepository.cs
│   └── IReviewerRepository.cs
│
├── Models/
│   ├── Pokemon.cs
│   ├── Category.cs
│   ├── Owner.cs
│   └── Review.cs
│   └── Reviewer.cs
│
├── Repositories/
│   ├── PokemonRepository.cs
│   ├── CategoryRepository.cs
│   ├── OwnerRepository.cs
│   └── ReviewRepository.cs
│   └── ReviewerRepository.cs
│
├── AutoMapperProfiles/
│   └── MappingProfile.cs
│
├── PokemonReviewApp.csproj
├── appsettings.json
├── Seed.cs
└── Program.cs
```
#### Key Folders
**Controllers**: Handles API requests and sends responses.
**Dtos**: Data Transfer Objects used to transfer data between client and server.
**Interfaces**: Defines the contract for repositories.
**Repositories**: Implements data access logic.
**Models**: Database entities representing Pokémon, categories, owners, and reviews.
**AutoMapperProfiles**: Configuration for AutoM
### Usage
- **Swagger UI**: Open [http://localhost:3000/swagger](http://localhost:3000/swagger) in your browser to access the Swagger UI for testing the APIs interactively.
- **Postman**: Import the API collection from the Swagger endpoint to test the APIs in Postman(optional).
- **Database Seeding**: You can also use the seed script written and seed some data in your database by using the command
```bash
dotnet run seeddata
```
#### Contributing
If you'd like to contribute, feel free to fork the repository and submit a pull request.

- Create a new feature branch (git checkout -b feature-branch)
- Commit your changes (git commit -am 'Add new feature')
- Push to the branch (git push origin feature-branch)
- Open a Pull Request
- Create an issue with your contribution and link it to your PR.
