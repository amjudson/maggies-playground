# Maggie's Playground

A full-stack web application featuring a .NET 9 API backend with PostgreSQL and a React 19 frontend with Redux Toolkit.

## Project Overview

This project demonstrates modern web development practices with a focus on:
- Secure user authentication and authorization using JWT
- RESTful API development with ASP.NET Core
- React frontend with TypeScript and Redux for state management
- PostgreSQL database with Entity Framework Core

## Backend (.NET 9 API)

### Technology Stack
- ASP.NET Core 9.0
- Entity Framework Core 9.0
- PostgreSQL database
- Identity Framework for authentication
- JWT for token-based authorization
- Swagger for API documentation

### Features
- User authentication (register, login)
- Role-based authorization
- Client management

## Frontend (React 19)

### Technology Stack
- React 19.1
- TypeScript 4.9
- Redux Toolkit for state management
- React Router v7 for routing
- SCSS for styling

### Features
- Modern responsive UI
- Redux state management
- Protected routes with authentication

## Getting Started

### Prerequisites
- .NET 9 SDK
- Node.js and Yarn
- PostgreSQL database
- JetBrains Rider (recommended for backend development)
- WebStorm (recommended for frontend development)

### Running the Backend
1. Navigate to the `MaggiesPlaygroundApi` directory
2. Configure your PostgreSQL connection string in `appsettings.json`
3. Run migrations: `dotnet ef database update`
4. Start the API: `dotnet run`
5. Access Swagger UI at `https://localhost:5001/swagger`

### Running the Frontend
1. Navigate to the `maggies-playground-client` directory
2. Install dependencies: `yarn install`
3. Start the development server: `yarn start`
4. Access the application at `http://localhost:3000`

## Current Development
- Setting up authorization system with JWT
- Implementing client management functionality
- Creating responsive layouts and components

## License
[Your license information here]
