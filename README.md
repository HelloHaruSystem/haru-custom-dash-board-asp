# Personal Dashboard API

Backend API for my personal dashboard website.

## Work in Progress 

This is currently under development.

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQLite (development) / PostgreSQL (production)
- JWT Authentication

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Entity Framework Core CLI tools

```bash
# Install EF Core CLI tools globally (if not already installed)
dotnet tool install --global dotnet-ef
```

### Setup

1. **Clone and restore packages:**
```bash
git clone <https://github.com/HelloHaruSystem/haru-custom-dash-board-asp.git>
cd PersonalDashBoard.Api
dotnet restore
```

2. **Configure application settings:**
Create or update your `appsettings.json`file:
```json
{
  "Authentication": {
    "MasterSecret": "your-super-secret-key-here"
  },
  "ConnectionStrings": {
    "DevelopmentConnection": "Data Source=./Database/dashboard.db"
  }
}
```

3. **Setup development database:**
```bash
# Create initial migration
dotnet ef migrations add InitialCreate

# Apply migration (creates SQLite database file)
dotnet ef database update
```

4. **Run the application:**
```bash
dotnet run
```

## Database

- **Development**: Uses SQLite database stored in `./Database/dashboard.db`
- **Production**: Configured for PostgreSQL (connection string in appsettings.Production.json)

## Configuration

- **MasterSecret**: Required for user registration. Change this to your own secret key.

## Features (Planned)

- [ ] User authentication
- [ ] Link/bookmark management
- [ ] File uploads
- [ ] Dashboard stats