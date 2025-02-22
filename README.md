# Project documentation

# TrackIt - App inventory tracker

This website allows users to register and login to access features. They are given access to a list of products and the ability to update this list through a variety of options found attached to the products.

This software was created primarily as an intro to the .NET framework. We use Blazor for our file handling and components. The project is housed and hosted with Azure DevOps.

[Software Demo Video](#)

## Team Members

- Anesu Shangwa
- Diego Vasquez
- Kami Smith
- Joseph Wallace

## Development Environment

- Visual Studio Code
- C#
- ASP.NET core 8.0.204
- Git
- Azure

## Useful Websites

- [Azure Ref Doc](https://learn.microsoft.com/en-us/azure/?product=popular)
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)

## Installation

Follow these steps to set up the project locally:

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (Ensure you have at least version `8.0.404`)
- [Neon Serverless Postgres](https://neon.tech/) (Create an account sign in with github or your preferred method)

### Setup Steps

1. **Clone the repository:**

   ```bash
   git clone https://Team4-Organization@dev.azure.com/Team4-Organization/CSE325-Team4/_git/CSE325-Team4
   ```

2. **Navigate to the project directory:**

   ```bash
   cd trackit
   ```

3. **Restore dependencies:**

   ```bash
   dotnet restore
   ```

4. **Set up the database (if applicable):**

   - Update `appsettings.json` with your database connection string (You can get the connection string setting a neon database).
   - Apply migrations:
     ```bash
     dotnet ef database update
     ```

5. **Run the application:**

   ```bash
   dotnet run or dotnet watch
   ```

6. **Access the application:**
   - Open a browser and go to `http://localhost:5000` (or whatever port your app runs on).

## Usage

The functionality of the App is based on services that help to manage the logic with the database and provides the necessary methods to perform all the CRUD operations, specifically with the products.

### Services

- **AuthService**: It handles all the operations necessary to sign a user in and sign out. It also handles the logic of comparing the user's password when logging in.
- **UserService**: Specifically handles the functionality of registering a user and returning a user based on the username.
- **ProductService**: It handles all the operations necessary to add, edit, view, and delete a product. It also contains a method to obtain a list of products.
- **CategoryService**: It handles all the operations necessary to obtain a list of categories in order to populate the dropdown in the edit and add product form, it also contains a method to obtain a category based on the ID.

### Basic Functionality

- Log in if you already have a registered user. If not, click the **Register** button to create one. The password must be between 8 and 20 characters long.
- In the top menu, you'll find options to view the product list or add a new product.
- The **product list** is a table with a filtering option based on the name. Each product has buttons to edit, delete, or view its details.
- To **add a product**, fill in the required fields in the form. The image URL is optional.
- To **edit a product**, click the "Edit" button. This will take you to a form where you can modify the necessary details. Keep in mind that the price and stock quantity cannot be zero or negative.
- To **delete a product**, click the corresponding button. You will have the option to confirm the deletion or cancel the action, which will take you back to the product list.
- If you try to **access a protected page** (such as the product list or product details) without being logged in, you will be redirected to the login page.
- If you try to visit a **non-existent route**, the app will display a message and automatically redirect you to the home page after 5 seconds.
