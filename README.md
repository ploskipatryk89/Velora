# Velora

Modern personal finance management application built with ASP.NET Core, Blazor, and .NET MAUI.

Velora helps users manage personal finances by tracking expenses, planning budgets, monitoring loans and bills, and analyzing financial data in one place.

## Features

- User authentication with JWT
- Expense and income tracking
- Budget management
- Loan and bill management
- Payment reminders
- Financial statistics and analytics

## Tech Stack

### Backend

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- FluentValidation
- MediatR
- CQRS

### Web

- Blazor
- C#
- Razor Components
- CSS

### Mobile

- .NET MAUI
- XAML
- MVVM

### Shared

- Shared DTOs
- Request / Response contracts
- Common models

## Architecture

- Clean Architecture
- Vertical Slice Architecture
- CQRS

## Project Structure

```text
Velora/

├── backend/
│   └── Velora.Api
│
├── frontend/
│   ├── Velora.Web
│   └── Velora.Mobile
│
└── shared/
    └── Velora.Shared
```

## Future Plans

The primary goal of this project is to learn and explore the Microsoft ecosystem by building the application with:

- ASP.NET Core
- Blazor
- .NET MAUI

After the core functionality is completed, the web frontend may be rebuilt using:

- React
- TypeScript

This will allow direct comparison between Blazor and React while keeping the same backend and business logic.

## Status

🚧 Project in development
