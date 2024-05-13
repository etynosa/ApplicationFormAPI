# .NET 8 Web Application - Questionnaire

This .NET 8 web application allows users to create, update, retrieve, and delete questions for a questionnaire. It utilizes Azure Cosmos DB for data storage and provides endpoints for CRUD operations.

## Features

- Create questions with different types: Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number.
- Update existing questions.
- Retrieve questions based on their ID.
- Delete questions.
- Data storage in Azure Cosmos DB for NoSQL.

## Technologies Used

- .NET 8
- Azure Cosmos DB
- xUnit for unit testing

## Setup

1. Clone the repository.
2. Ensure you have .NET 8 SDK installed.
3. Set up Azure Cosmos DB and obtain the connection string.
4. Update the connection string in `appsettings.json`.
5. Run the application.

