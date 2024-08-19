# MongoDB Web API

This project is a simple ASP.NET Core Web API that connects to a MongoDB database, retrieves a crypted key, and provides basic CRUD operations on a `Person` collection. It serves as a foundational example for integrating MongoDB with .NET applications.

## Features

- **Connect to MongoDB:** Retrieve a crypted key from MongoDB, required for subsequent operations.
- **CRUD Operations:** Basic Create and Read operations for managing `Person` entities in MongoDB.
- **Separation of Concerns:** The logic for MongoDB interactions is encapsulated in a service class (`MongoDBService`).

## Technologies Used

- **.NET 6 or 7**: The latest LTS or non-LTS version of .NET.
- **ASP.NET Core Web API**: Framework for building RESTful APIs.
- **MongoDB.Driver**: Official MongoDB driver for .NET.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/try/download/community) (Installed and running)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/Yassiinee/MongoDBWebAPI.git
   cd MongoDBWebAPI
