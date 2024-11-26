# Sales Management API

## About the Project

This project is a **Sales Management API** designed to handle CRUD operations for managing sales records. It provides a set of endpoints to create, retrieve, update, and delete sales data, along with associated business logic to enforce rules such as discounts based on item quantities. The API is built following **Domain-Driven Design (DDD)** principles and leverages modern .NET technologies for scalability, maintainability, and performance.

---

## Features

### 1. **Sales Record Management**
- Store information about sales, including:
  - Sale numbers
  - Dates
  - Customers
  - Branches
  - Associated items
- Record details for each sale item, such as:
  - Quantity
  - Unit price
  - Discounts
  - Cancellation status

### 2. **Business Logic**
- Enforce discount rules based on item quantity:
  - **10% discount** for quantities of **4-9 items**.
  - **20% discount** for quantities of **10-20 items**.
  - Restrict sales to a maximum of **20 items** per product.
  - No discounts for quantities **below 4 items**.

### 3. **Validation**
- Ensures data integrity with validations for:
  - Required fields
  - Logical constraints
  - Business rules

### 4. **RESTful API Design**
- Clean and well-documented endpoints for client integration.
- Standardized request and response formats for easier consumption.

### 5. **Error Handling**
- Provides clear and structured error responses for:
  - Validation failures
  - Not found cases
  - General issues

---

## Use Cases

This API can be used in a variety of scenarios, such as:
- Managing sales records for retail or e-commerce platforms.
- Integrating with front-end applications to display and modify sales data.
- Enforcing business-specific sales rules programmatically.

---

## Goals

The project is designed to demonstrate:
- Proficiency in backend development.
- Adherence to best practices for:
  - Code quality
  - Scalability
  - Maintainability
- Skills in API design, business rule implementation, and validation.

# Endpoints

### POST `/api/Sales`
Creates a new sale record.

**Request Body:**
```json
{
  "saleNumber": "string",
  "saleDate": "2024-11-26T15:48:06.945Z",
  "customer": "string",
  "branch": "string",
  "createdBy": "string",
  "items": [
    {
      "product": "string",
      "quantity": 0,
      "unitPrice": 0
    }
  ]
}
```

### **Responses**

**201 Created:**
```json
{
  "success": true,
  "message": "string",
  "errors": [],
  "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "saleNumber": "string",
    "saleDate": "2024-11-26T15:48:06.945Z",
    "customer": "string",
    "branch": "string",
    "totalAmount": 0,
    "isCancelled": true,
    "items": [
    {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "product": "string",
        "quantity": 0,
        "unitPrice": 0,
        "discount": 0,
        "totalAmount": 0,
        "isCancelled": true
      }
    ]
  }
}
```

**400 Bad Request**
```json
{
  "success": false,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

### GET `/api/Sales`
Retrieves a list of all sales.

**Query Parameters: None**
### **Responses**

**200 OK:**
```json
{
  "success": true,
  "message": "string",
  "errors": [],
  "data": [
    {
      "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "saleNumber": "string",
      "saleDate": "2024-11-26T15:48:06.945Z",
      "customer": "string",
      "branch": "string",
      "totalAmount": 0,
      "isCancelled": true,
      "items": [
        {
          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "product": "string",
          "quantity": 0,
          "unitPrice": 0,
          "discount": 0,
          "totalAmount": 0,
          "isCancelled": true
        }
      ]
    }
  ]
}
```

### GET /api/Sales/{id}
Retrieves a specific sale by its ID.

**Path Parameters:**
- id (required): UUID of the sale to retrieve.

**Responses:**

**200 OK**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ],
  "data": {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "saleNumber": "string",
    "saleDate": "2024-11-26T16:59:59.328Z",
    "customer": "string",
    "branch": "string",
    "totalAmount": 0,
    "isCancelled": true,
    "items": [
      {
        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "product": "string",
        "quantity": 0,
        "unitPrice": 0,
        "discount": 0,
        "totalAmount": 0,
        "saleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
      }
    ]
  }
}
```

**400 Bad Request**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

**404 Not Found**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

### DELETE /api/Sales/{id}
Deletes a sale by its ID.

**Path Parameters:**
-id (required): UUID of the sale to delete.

**Responses:**

**200 OK**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

**400 Bad Request**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

**404 Not Found**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

### PUT /api/Sales/{id}
Updates a sale by its ID.

**Path Parameters:**
-id (required): UUID of the sale to update.

**Request Body:**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "saleNumber": "string",
  "customer": "string",
  "branch": "string",
  "isCancelled": true,
  "updatedBy": "string"
}
```

**Responses:**

**200 OK**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

**400 Bad Request**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

**404 Not Found**
```json
{
  "success": true,
  "message": "string",
  "errors": [
    {
      "error": "string",
      "detail": "string"
    }
  ]
}
```

## How to Run this Project

### Prerequisites
- .NET 8 or higher
- PostgreSQL Database
- Any REST client (e.g., Postman) or browser for testing API endpoints.

### Steps
1. Clone the repository:   
   - git clone <https://github.com/RicardoZitelli/AmbevAvaliacao.git>

2. Navigate to the project directory:   
   - cd <project-folder>

3. Setup the database:
   - Ensure PostgreSQL is installed and running.
   - Create a new database (e.g., `DeveloperEvaluation`).
   - Update the connection string in `appsettings.json`.

4. Run migrations to create the necessary tables:   
   - dotnet ef database update

5. Start the application:
   - dotnet run
