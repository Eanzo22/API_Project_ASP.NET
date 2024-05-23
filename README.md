# E-Commerce API

## Overview
This project is a backend API for an e-commerce application. It includes functionalities for managing products, carts, and orders. It also supports user authentication and authorization.

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server 

### Setup

1. Clone the repository:
    ```bash
    git clone https://github.com/Eanzo22/API_Project_ASP.NET.git
    cd ecommerce-api
    ```

2. Update the `appsettings.json` with your database connection string and JWT settings.

3. Apply migrations and seed data:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

4. Run the application:
    ```bash
    dotnet run
    ```

### Endpoints

#### Products

- **Get All Products**
  - `GET /api/products`
  - Query Parameters: `category` (optional), `name` (optional)

- **Get Product By ID**
  - `GET /api/products/{id}`

- **Create Product**
  - `POST /api/products`
  - Request Body: `CreateProductDto`
  - Authorization: Admin

- **Update Product**
  - `PUT /api/products`
  - Request Body: `UpdateProductDto`
  - Authorization: Admin

- **Delete Product**
  - `DELETE /api/products/{id}`
  - Authorization: Admin

#### Cart

- **Add To Cart**
  - `POST /api/cart/add`
  - Request Body: `AddToCartDto`
  - Authorization: User

  - **View All Carts**
  - `GET /api/cart/`
  - Authorization: User

- **Remove From Cart**
  - `POST /api/cart/remove`
  - Request Body: `RemoveFromCartDto`
  - Authorization: User

- **Update Cart Item**
  - `POST /api/cart/EditItemQuantity`
  - Request Body: `EditCartItemDto`
  - Authorization: User

#### Orders

- **Place Order**
  - `POST /api/orders/placeOrder`
  - Request Body: `List<AddOrderItemsDto>`
  - Authorization: User

- **Order History**
  - `GET /api/orders/ViewOrdersHistory`
  - Authorization: User
  
- **Get all Orders**
  - `GET /api/orders/`
  - Authorization: Admin
### Technologies Used

- .NET 8
- Entity Framework Core
- JWT Authentication
- ASP.NET Core MVC
- SQL Server

### Contributing
To contribute, please fork the repository and use a feature branch. Pull requests are warmly welcome.


### Demo Video
[Watch the demo video]()
