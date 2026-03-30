# Japanese Car Parts Store

This is my project for the ASP.NET Fundamentals Jan. 2026. It's a web application where users can find parts for specific Japanese cars (Honda, Toyota, Mazda).

I built this because I wanted to create a system where you don't just see a giant list of parts—you first pick your car (Brand and Model), and then the site shows you exactly what fits.

## How It Works

### For Users (Public Side)
*   **Select a Car:** You can pick a Brand (like Honda) and then a specific Model (like Civic).
*   **See the Car:** Once you pick a model, I added a feature where the image of that specific car generation shows up so you know you picked the right one.
*   **Buy Parts:** You can see the list of parts (Body, Mechanical, Cooling, etc.) available for that car.

### For Admins (Private Side)
*   **Admin Panel:** I created a separate area for managing the data.
*   **Add New Parts:** You can add parts to the database, set their price, and paste an image URL.
*   **Manage Inventory:** You can Edit or Delete parts if the price changes or if there is a mistake.
*   **Validation:** The forms check if you missed a required field (like Price or Name) before saving.

## Tools I Used
*   **ASP.NET Core MVC (.NET 8):** The main framework.
*   **Entity Framework Core:** To handle the database and relationships between Brands, Models, and Parts.
*   **SQL Server:** I used LocalDB for development.
*   **Bootstrap 5:** For the layout and responsive design.

## How to Run This Project

1.  **Clone the repo:** Download the files to your computer.
2.  **Check the Database Connection:**
    *   Go to `appsettings.json`.
    *   I used `(localdb)\mssqllocaldb`. If you are using SQL Express, you might need to change the connection string.
3.  **Create the Database:**
    *   Open Visual Studio.
    *   Go to **Tools** -> **NuGet Package Manager** -> **Package Manager Console**.
    *   Run the command: `Update-Database`
4.  **Run the App:**
    *   Press **F5**.
    *   **Note:** When you run it for the first time, the app will automatically fill the database with the 3 brands (Honda, Toyota, Mazda) and enough sample parts so you don't have to type them in manually.

## Known Issues & Future Plans

Since this is a course project, there are a few things I want to improve later:
*   **Search bar:** The future version of the project will include a search bar.
*   **Images:** Currently, I use image URLs from the internet. In the future, I want to add file uploading so images are saved on the server.
*   **Admin:** The admin panel has to be greatly improved upon by adding the ability to create and remove vehicle models as well as entire brands.
*   **User experience:** Since the part list and overall number of brands and models will be expanded, the way parts will be displayed will be broken down into seperate categories for a more user-friendly experience.
*   **User Accounts:** Right now, the Admin panel is open. I plan to add ASP.NET Identity later to secure it with a login screen. Regular users will also be able to have accounts and the admins will be able to edit their accounts (add or remove discounts, fix invoices)
*   **Shopping Cart:** I want to add a real cart and checkout process in the next version.
*   **Languages:** I also want to add one or two more languages for the site - starting with german.

## License
This is an educational project.
