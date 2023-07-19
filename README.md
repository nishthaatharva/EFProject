# EFProject

# Entity Framework
- Entity Framework is an Object/Relational Mapping (O/RM) framework. It is an enhancement to ADO.NET that gives developers an automated mechanism for accessing & storing the data in the database.

# Repository-service pattern
- It provides data abstraction and 
- data encapsulation

### What is Repository Design Pattern?
- Repository is just a class that is associated with some entity and it manages all possible actions of that entity including CRUD operation.
- For example we have a Student entity then , a Student repository will contain these basic methods e.g. Add , Update , Get , GetById and Delete
- The Repository Pattern is a layer that mediates between the domain and the data access layers. It's like a buffer that controls how data is accessed and manipulated.
- Repository is just a class that is associated with some entity and it manages all possible actions of that entity including CRUD operation.
-For example we have a Student entity then , a Student repository will contain these basic methods e.g. Add , Update , Get , GetById and Delete
-The Repository Pattern is a layer that mediates between the domain and the data access layers. It's like a buffer that controls how data is accessed and manipulated

# Solid Principal:
- SOLID principles are particularly relevant for agile development, as they help create flexible, scalable, and easy to modify code. Readable, reusable, maintainable and scalable code
- SOLID is a mnemonic device for 5 design principles of object-oriented programs (OOP) that result in readable, adaptable, and scalable code. SOLID can be applied to any OOP program.

## The 5 principles of SOLID are:	
- Single-responsibility principle
- Open-closed principle
- Liskov substitution principle
- Interface segregation principle
- Dependency inversion principle

- **S** : Single Responsibility Principle“A class should only have a single responsibility, that is, only changes to one part of the software’s specification should be able to affect the specification of the class.” ENCAPSULATION 
- **O** : Open Closed Principle:“Software entities … should be open for extension, but closed for modification.” POLYMORPHISM
- **L** : Liskov substitution principle :"Objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program." Overriding, Inheritance
- **I** : Interface segregation principle : "Many client-specific interfaces are better than one general-purpose interface."
	Any unused part of the method should be removed or split into a separate method.
- **D** : Dependency inversion principle : “One should depend upon abstractions, [not] concretions.” 
	If you minimize dependencies, changes will be more localized and require less work to find all affected components.

# Clean architecture:
### Domain, Application, Infrastucture & Presentation/API
- Clean architecture is a software architecture that helps us to keep an entire application code under control. The main goal of clean architecture is the code/logic, which is unlikely to change. It has to be written without any direct dependency. This means that if I want to change my development framework OR User Interface (UI) of the system, the core of the system should not be changed. It also means that our external dependencies are completely replaceable.
Domain-Driven Design (DDD)

## Benefits of Clean Architecture:
- Independent of Database and Frameworks.
- Independent of the presentation layer. Anytime we can change the UI without changing the rest of the system and business logic.
- Highly testable, especially the core domain model and its business rules are extremely testable.

- main web api project: controller, dependencies injections
- Infra: Migrations, services, data(data-context) ---- database related manipulation etc.
- Domain: Entities
- Application: Interfaces,CQRS ---- exception handling etc, custom exceptions(Middleware)

# CQRS: Command Query Responsibily Segregation
- The core idea of this pattern is to separate Read and Update operations by using different models to handle the treatment. We use commands to update data, and queries to read data.
- CQRS stands for “Command Query Responsibility Segregation”. As the acronym suggests, it’s all about splitting the responsibility of commands (saves) and queries (reads) into different models.
- If we think about the commonly used CRUD pattern (Create-Read-Update-Delete), usually we have the user interface interacting with a datastore responsible for all four operations. CQRS would instead have us split these operations into two models, one for the queries (aka “R”), and another for the commands (aka “CUD”)
- It helps to differentiate CRUD operations

## Command :
- “Add a New Product”: this scenario is a command operation because it’ll make a change to the system. manipulate data, repository can be used.

### What problem is this trying to solve?
- Well, a common reason is often when we design a system, we start with the data storage. We perform database normalization, add primary and foreign keys to enforce referential integrity, add indexes, and generally ensure the “write system” is optimized. This is a common setup for a relational database such as SQL Server or MySQL. Other times, we think about the read use cases first, then try and add that into a database, worrying less about duplication or other relational DB concerns (often “document databases” are used for these patterns).
- Neither approach is wrong. But the issue is that it’s a constant balancing act between reads and writes, and eventually one side will “win out”. All further development means both sides need to be analyzed and often one is compromised.
- CQRS allows us to “break free” from these considerations, and give each system the equal design and consideration it deserves, without worrying about the impact of the other system. This has tremendous benefits on both performance and agility, especially if separate teams are working on these systems.

# Mediator Pattern :	
- The Mediator pattern is simply defining an object that encapsulates how objects interact with each other. Instead of having two or more objects take a direct dependency on each other, they instead interact with a “mediator”, who is in charge of sending those interactions to the other party
- using mediatR pattern we can encapsulate object for interaction with each other.

# Fluent Validation :
- The FluentValidation library allows us to easily define very rich custom validation for our classes. Since we are implementing CQRS, it makes the most sense to define validation for our Commands.
- We should not bother ourselves with defining validators for Queries, since they don’t contain any behavior. We use Queries only for fetching data from the application.
- Fluent Validation is a popular open-source validation library used to solve complex validation requirements. It is a third-party validation library for .NET that uses an easy-to-use fluent interface for building strongly typed validation rules. Used to solve complex validation requirements.
- It is a server-side framework used to create advanced and complex validations for the user data. It is a great tool to help make your validation easy to create and easy to maintain.

### I prefer Fluent Validation:
- It gives me far better control of my validation rules.
- Doing conditional validation on different properties is so much easier compared to Data Annotations.
- It separates the validation from my view models.
- Unit testing is far easier compared to Data Annotations.
- It has excellent client side validation support for most standard validation rules.	



