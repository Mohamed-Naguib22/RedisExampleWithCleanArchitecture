# RedisExampleWithCleanArchitecture

## Project Overview
Demonstration project that follows the Clean Architecture principles while integrating various key technologies and design patterns integrated with Redis Caching Database to improve the performance.

## Features

* Clean Architecture: Follows Uncle Bob's Clean Architecture, separating concerns into different layers such as Domain, Application, Persistence, Infrastructure, and Presentation.

* Redis Caching: Uses Redis for efficient caching, improving the application's performance by reducing load on the database.

* AutoMapper: Automatically maps objects from Data Transfer Objects (DTOs) to Domain Models and vice versa.

* Fluent Validation: Implements validation logic in a clean and readable manner for user inputs.

* Serilog: Provides structured and powerful logging for application diagnostics and troubleshooting.

* Docker: Easily containerize and run the application using Docker for consistent environments across development, testing, and production.

* Global Exception Handling: A centralized mechanism for catching and handling all exceptions in a unified manner.

* Specification Pattern: Encapsulates business logic queries in a reusable and maintainable way.

* Unit of Work & Generic Repository: Provides a clean way of managing database operations with transactions and abstractions.

* CQRS: Separates the reading and writing logic into distinct parts, improving scalability and maintainability.

* Fluent API: Configures entity relationships and database schemas in a fluid and readable manner using the Fluent API.

* SQL Server: Utilizes SQL Server for relational data storage, supporting the application’s persistence layer.

## Technologies & Frameworks
* .NET Core for the application framework
* Redis for caching
* AutoMapper for object mapping
* FluentValidation for input validation
* Serilog for logging
* Docker for containerization
* Entity Framework Core (with Fluent API) for database interactions
* SQL Server for relational database storage
