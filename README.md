# Restaurant Management Application

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![HTML](https://img.shields.io/badge/HTML5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![ASP.NET](https://img.shields.io/badge/ASP.NET-%235C2D91.svg?style=for-the-badge&logo=dot-net&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-%23563D7C.svg?style=for-the-badge&logo=bootstrap&logoColor=white)

A full-stack web application developed in C# designed for managing restaurant data, including menus, categories, and members. This application enables administrators to add, edit, and delete restaurant data, while regular users can browse restaurant details, view menu items, and filter options. Built with ASP.NET Core MVC, this project demonstrates the use of role-based access control, CRUD functionality, and a responsive UI.

![Restaurant Application Screenshot](https://github.com/iliesdragos/Ilies_Dragos_Restaurant/blob/master/screenshots/index.png)

## Features

### Restaurant Management
- **View Restaurants**: Users can see a list of available restaurants with details like name, address, category, and menu description.
- **View Restaurant Details**: Users can click on a restaurant to view detailed information, including menu items, descriptions, and prices.  
  ![Restaurant Details Screenshot](https://github.com/iliesdragos/Ilies_Dragos_Restaurant/blob/master/screenshots/restaurant_details.png)
- **Search & Sort**: Search restaurants by name or category and sort them alphabetically.
- **Admin Privileges**: Administrators can add new restaurants, edit existing ones, or delete entries. They can also manage menus, categories, and members.

### User Roles and Authentication
- **Role-Based Access**: Only admins have permission to modify data. Regular users can view restaurant and menu information.
- **User Authentication**: Users can register, log in, and access features based on their roles.

## Technology Stack

### Frontend
- **HTML**: Used for structuring the web pages.
- **ASP.NET Core MVC**: For building the web application's frontend and handling UI.
- **Bootstrap**: Used for styling and ensuring a responsive design.

### Backend
- **C#**: Primary programming language used for backend logic.
- **Entity Framework Core**: Handles database operations and migrations.
- **SQL Server**: Database for storing restaurant, menu, and user data.

### Authentication
- **ASP.NET Identity**: Provides secure user authentication and role management.

## Installation

To set up the project locally, follow these steps:

1. Clone this repository:
   ```bash
   git clone https://github.com/iliesdragos/Ilies_Dragos_Restaurant.git
   
2. Open the project in Visual Studio.

3. Configure the database connection:
   - Open the `appsettings.json` file.
   - Replace the default connection string with your SQL Server configuration. It should look something like this:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=IliesDragosRestaurantDB;Trusted_Connection=True;"
     }
     ```
   - Replace `YOUR_SERVER_NAME` with your SQL server name.

4. Run migrations to create the database schema:
   - Open **Package Manager Console** in Visual Studio.
   - Run the following command to create the necessary tables in the database:
     ```bash
     Update-Database
     ```

5. Build and run the project:
   - Click on **Start** in Visual Studio, or use the following command in the terminal to run the application:
     ```bash
     dotnet run
     ```
## Running the Project

- **Admin Account**: Log in with an admin account to access all management features (add/edit/delete).
- **User Account**: Log in with a regular account to view restaurant details without editing permissions.

## Future Improvements

- **Additional Authentication Providers**: Integrate Google or Facebook login options.
- **User Reviews**: Allow users to add reviews and ratings for each restaurant.
- **Advanced Filters**: Enhance the search with filters for specific menu items or restaurant categories.
