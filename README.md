# Articles Postgres CRUD
This repository contains a .NET Core Web API project designed to perform CRUD (Create, Read, Update, Delete) operations on articles stored in a PostgreSQL database. The project is containerized using Docker, making it easy to deploy and manage.

## Features
CRUD Operations: Seamlessly create, read, update, and delete articles.
PostgreSQL Integration: Utilizes PostgreSQL for robust and scalable data storage.
Docker Support: Includes Docker and Docker Compose configurations for easy containerization and deployment.
RESTful API: Exposes a RESTful API for interacting with the articles.


# Getting Started
## Prerequisites
- Docker and Docker Compose installed on your machine.
- .NET Core SDK installed for local development.

## Installation
1. Clone the repository
    ```bash
    git clone https://github.com/ajaybhalerao12/articles-postgres-crud.git
    cd articles-postgres-crud
    ```
2. Build and run the Docker containers:
    ```bash
    docker-compose up --build
    ```
3. Access the API:
   - The API will be available at http://localhost:5000.   

## Configuration
Update your appsettings.json to include the PostgreSQL connection string:    

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=db;Database=appdb;Username=appuser;Password=apppassword"
  }
}
```

## Contributing
Feel free to open issues and submit pull requests. Contributions are welcome!

## License
This project is licensed under the MIT License - see the LICENSE file for details.