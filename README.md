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

## Authentication

This API uses JWT Bearer token authentication. To access the protected endpoints, you need to include a valid JWT token in the `Authorization` header of your requests.
## Authentication

To use the authentication feature, follow these steps:

1. **Login to generate a token:**
   - Endpoint: `/login`
   - Method: `POST`
   - Request Body:
     ```json
     {
       "username": "test",
       "password": "password"
     }
     ```

2. **Example Request:**
   ```bash
   curl -X POST http://localhost:3000/login \
   -H "Content-Type: application/json" \
   -d '{
     "username": "test",
     "password": "password"
   }'
   ```
3. Response:
  - On successful login, you will receive a JWT token in the response.
4. Use the token:
  - Include the token in the Authorization header of your requests to access protected routes.
    ```bash
    curl -X GET http://localhost:3000/protected-route \
-H "Authorization: Bearer <your-jwt-token>"
    ```
    Make sure to replace <your-jwt-token> with the token you received from the login response.

## API Endpoints
### Articles Controller
#### Get All Articles
- URL: /api/articles
- Method: GET
- Description: Retrieves a list of all articles.

####  Get Article by ID
- URL: /api/articles/{id}
- Method: GET
- Description: Retrieves a single article by its ID.
- 
#### Create a New Article
- URL: /api/articles
- Method: POST
- Description: Creates a new article.
- Request Body:
```bash
{
    "title": "string",
    "content": "string"
}
```

#### Update an Article
- URL: /api/articles/{id}
- Method: PUT
- Description: Updates an existing article by its ID.
- Request Body:
```bash
{
    "id": 1,
    "title": "Updated Title",
    "content": "Updated Content",
    "createdAt": "2023-08-25T18:51:28"
}
```

#### Delete an Article
- URL: /api/articles/{id}
- Method: DELETE
- Description: Deletes an article by its ID.

## Contributing
Feel free to open issues and submit pull requests. Contributions are welcome!!

## License
This project is licensed under the MIT License - see the LICENSE file for details.