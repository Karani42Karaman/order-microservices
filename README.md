# Order Microservices

## 🧾 Introduction

This project is a **.NET Core-based microservices architecture** that manages customer and order operations. It includes two main services (`CustomersApi`, `OrdersApi`) and an API Gateway (`ApiGateway`) built using **Ocelot**. Each service operates independently and maintains its own database, promoting scalability and separation of concerns.

## 📚 Table of Contents

- [Architecture](#architecture)
- [Features](#features)
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Project Structure](#project-structure)
- [Troubleshooting](#troubleshooting)
- [Contributors](#contributors)
- [License](#license)

## 🏗️ Architecture

This microservices solution consists of:

- **ApiGateway**: Routes requests to backend services using Ocelot.
- **CustomersApi**: Handles customer-related operations and data.
- **OrdersApi**: Handles order processing and data.
- **Docker**: Uses Docker Compose to orchestrate services and databases.

Each microservice:
- Is deployed independently
- Connects to its own isolated database
- Communicates externally via the API Gateway

## ✨ Features

- .NET Core microservices with REST APIs
- API Gateway routing with Ocelot
- Dockerized environment using Docker Compose
- Individual MySql (or other) databases per service
- Loose coupling between services
- Easily scalable and maintainable

## 🛠️ Technologies

- [.NET Core](https://dotnet.microsoft.com/)
- [Ocelot](https://ocelot.readthedocs.io/en/latest/) – API Gateway
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- PostgreSQL (assumed for DBs)

## 📦 Installation

> ⚠️ Prerequisites:  
> - Docker & Docker Compose installed  
> - [.NET SDK](https://dotnet.microsoft.com/download) (for local development/testing)

To start the entire stack:

```bash
cd Docker
docker-compose up -d
