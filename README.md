# Onion Architecture in .NET Core with EF Code First

This repository demonstrates the implementation of the Onion Architecture in .NET Core using the Entity Framework (EF) Code First approach.

## Overview

Onion Architecture is a software architectural pattern that provides a way to structure an application to manage dependencies. The core idea is to build the application around an independent domain layer, with other layers (such as infrastructure and UI) depending on the domain layer, but not on each other.

### Advantages of the Onion Architecture
All of the layers interact with each other strictly through the interfaces defined in the layers below. The flow of dependencies is towards the core of the Onion. We will explain why this is important in the next section.

Using dependency inversion throughout the project, depending on abstractions (interfaces) and not the implementations, allows us to switch out the implementation at runtime transparently. We are depending on abstractions at compile-time, which gives us strict contracts to work with, and we are being provided with the implementation at runtime.

## Entities

The database contains two main entities:

- `Student`: Represents the students in the system.
- `Department`: Represents the departments to which students can belong.

## EF Code First Approach

The EF Code First approach is used to define the database schema using C# classes. Migrations are used to update the database schema as the model changes over time.

## Project Structure

The project is structured into multiple layers:
- `Domain Layer`: Contains the entities and business logic.
- `Service or Application Layer`: Contains services that coordinate between the domain and infrastructure layers.
- `Infrastructure Layer`: Contains the EF DbContext, repositories, and other infrastructure-related code.
- `Presentation Layer`: The entry point of the application, typically a web API or MVC project.
<p align="center">
  <img style="width:500px; hight:500px;" alt="Onion Arch"
    src="https://code-maze.com/wp-content/uploads/2021/07/onion_architecture.jpeg" />
</p>

## Getting Started

To get started with this project:

1. Clone the repository.
2. Ensure you have .NET Core installed.
3. Navigate to the project directory and run `dotnet restore` to restore the packages.
4. Run `dotnet ef migrations add InitialCreate` to create the initial migration.
5. Run `dotnet ef database update` to apply the migration to the database.
6. Start the application with `dotnet run`.

## License

This project is licensed under the  Apache License - see the LICENSE file for details.
