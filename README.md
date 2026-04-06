# Japanese Car Parts Store - ASP.NET Advanced Project

This application is an e-commerce platform for Japanese car parts. It is developed as the final assignment for the **ASP.NET Advanced** course. The project focuses on a structured backend with role-based access and data persistence.

##  Project Structure
The application is organized into multiple layers to separate the user interface from the underlying data logic:

*   **Service Layer:** Business logic is located in the `Core` folder. Services like `PartService` and `OrderService` handle data processing and are called by controllers through interfaces (`IPartService`, `IOrderService`).
*   **Dependency Injection:** Built-in .NET dependency injection is used to manage service lifetimes and maintain a decoupled codebase.
*   **MVC Areas:** The application uses a dedicated `Admin` area for database management, separating administration tools from the public storefront.
*   **Data Models & ViewModels:** To protect the database schema, data is passed to the views using specific ViewModels (DTOs) rather than raw entities.

##  Key Functional Features
### Catalog and Search
- **Product Gallery:** Features a responsive list of parts with server-side pagination to manage load times.
- **Search Logic:** Includes a filtering system that queries by part name, brand, or description.
- **Product Details:** Provides an individual page for each item with specifications, images, and user reviews.

### Shopping and Orders
- **Shopping Cart:** Utilizes Session state to track items added to a user's cart before checkout.
- **Order Management:** When a purchase is completed, an Order and multiple OrderItems are stored in the database, preserving a history of the price at the time of purchase.
- **Review System:** Logged-in users can submit star ratings and comments on specific parts, which are displayed on the product details page.

### Security and Identity
- **User Roles:** Uses the ASP.NET Identity system with two distinct roles: `Administrator` and `User`.
- **Access Control:** The `[Authorize]` attribute is used to restrict the Admin Panel to administrators and ensure only registered users can view their order history or post reviews.
- **Data Validation:** Implements Data Annotations for both client-side (jQuery) and server-side (ModelState) validation to ensure data integrity.

##  Technical Specifications
- **7 Controllers:** Home, Part, Admin (Area), Error, Identity, Order, and Cart.
- **7 Database Entities:** Part, Brand, VehicleModel, ApplicationUser, Review, Order, and OrderItem.
- **Localization:** Configured in `Program.cs` to use `en-US` culture for consistent **USD ($)** and decimal formatting.

##  Testing and Validation
The project includes a separate NUnit 3 test project (`JapaneseCarpartsStore.Tests`) focused on validating the business logic in the Service layer.
*   **Frameworks:** Uses **Moq** for object mocking and an **Entity Framework Core In-Memory Database** to test database operations without a physical SQL instance.
*   **Scope:** Logic tests cover 65%+ of the code in the Services folder, ensuring critical methods like searching and retrieval are reliable.

##  Local Setup
1. Clone the repository and open the solution in **Visual Studio 2022**.
2. Configure the `DefaultConnection` in `appsettings.json` if required.
3. Open the Package Manager Console and execute **`Update-Database`**.
4. Launch the application (F5).

On the first run, the database is automatically seeded with several brands, corresponding car models and various performance parts.

**Default Administrator Account:**
- **Email:** `admin@store.com`
- **Password:** `Admin123!`

---
**Author:** Stefan Georgiev @StefanGeorgiev97
**Course:** SoftUni ASP.NET Advanced February 2026