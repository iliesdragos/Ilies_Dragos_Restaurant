# Restaurant Management Application

A full-stack web application developed in C# designed for managing restaurant data, including menus, categories, and members. This application enables administrators to add, edit, and delete restaurant data, while regular users can browse restaurant details, view menu items, and filter options. Built with ASP.NET Core MVC, this project demonstrates the use of role-based access control, CRUD functionality, and a responsive UI.

![Restaurant Application Screenshot](https://github.com/iliesdragos/Ilies_Dragos_Restaurant/blob/master/screenshots/index.png)

## Features

### Restaurant Management
- **View Restaurants**: Users can see a list of available restaurants with details like name, address, category, and menu description.
- **Search & Sort**: Search restaurants by name or category and sort them alphabetically.
- **Admin Privileges**: Administrators can add new restaurants, edit existing ones, or delete entries. They can also manage menus, categories, and members.

### Menu Management
- **Detailed Menu Items**: Each restaurant has a dedicated page listing its menu items, descriptions, and prices.
- **CRUD Operations for Admins**: Admins can create, edit, and delete menu items as well as assign them to restaurants.

### User Roles and Authentication
- **Role-Based Access**: Only admins have permission to modify data. Regular users can view restaurant and menu information.
- **User Authentication**: Users can register, log in, and access features based on their roles.

## Technology Stack

### Frontend
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
