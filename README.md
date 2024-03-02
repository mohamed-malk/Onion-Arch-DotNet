# Onion Architecture in .NET Core with EF Code First

This repository demonstrates the implementation of the Onion Architecture in .NET Core using the Entity Framework (EF) Code First approach.

## Overview

Onion Architecture is a software architectural pattern that provides a way to structure an application to manage dependencies. The core idea is to build the application around an independent domain layer, with other layers (such as infrastructure and UI) depending on the domain layer, but not on each other.

## Entities

The database contains two main entities:

- `Student`: Represents the students in the system.
- `Department`: Represents the departments to which students can belong.

## EF Code First Approach

The EF Code First approach is used to define the database schema using C# classes. Migrations are used to update the database schema as the model changes over time.

## Project Structure

The project is structured into multiple layers:

- `Domain Layer`: Contains the entities and business logic.
- `Infrastructure Layer`: Contains the EF DbContext, repositories, and other infrastructure-related code.
- `Application Layer`: Contains services that coordinate between the domain and infrastructure layers.
- `Presentation Layer`: The entry point of the application, typically a web API or MVC project.

## Getting Started

To get started with this project:

1. Clone the repository.
2. Ensure you have .NET Core installed.
3. Navigate to the project directory and run `dotnet restore` to restore the packages.
4. Run `dotnet ef migrations add InitialCreate` to create the initial migration.
5. Run `dotnet ef database update` to apply the migration to the database.
6. Start the application with `dotnet run`.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
