
# Sami Potter Online Shop C# MVC Website (Version 8 .NET Framework)

This project is a comprehensive harry potter online shop website developed using C# MVC (Model-View-Controller) framework on .NET Framework and using SQL Server Management as database. The website provides a platform for users to browse, order, and manage harry potter items, while also offering administrative functionalities for managing items, and users.


## Features

- User Roles: The website supports two roles - User and Admin. Users can browse items on the store, order items, and view items details, while Admins have additional privileges for managing the website and its contents.

- Item Ordering with PayPal Integration: Users can order items securely using PayPal payment integration, ensuring a smooth and convenient shopping experience.

- Item Ordering with Credit Card Integration: Users can order items securely using regular payment integration, ensuring a smooth and convenient shopping experience.

- Item Status: Items on the website are categorized into two statuses - Available, Expired.

- Detailed Item Information: Users can explore detailed item descriptions.

- Admin Dashboard: Admins have access to a comprehensive dashboard where they can add, edit, or delete items from the website and database. Additionally, they can view and manage users in the system.


## Installation

1. Clone this repository to your local machine.
2. Set up the required database using SQL Server Management
- In the appsettings.json file change the **TO-DO** to your database Connection String.
- In the package manager console use the seed function to create a deafult database:
    - Add-Migration InitialCreate
    - Update-Database
3. Build and run the application.
4. Register as a user or log in as an admin to access the respective functionalities.

## Screenshots

![App Screenshot](https://i.ibb.co/kK3syVm/1.png)

![App Screenshot](https://i.ibb.co/gZVJSgR/2.png)

![App Screenshot](https://i.ibb.co/8454yh2/3.png)

![App Screenshot](https://i.ibb.co/VHH8txW/4.png)

![App Screenshot](https://i.ibb.co/51xFNF3/5.png)

![App Screenshot](https://i.ibb.co/Ws3z8f9/6.png)


## Authors

* **Maor Atar** - *Software Engineer Student at Shamoon College of Engenering - SCE* - [Maor Atar](https://github.com/MaorAtar/)
* **Guy Ezra** - *Software Engineer Student at Shamoon College of Engenering - SCE* - [Guy Ezra](https://github.com/GuyEzra22/)
* **Yair Eliyahu** - *Software Engineer Student at Shamoon College of Engenering - SCE* - [Yair Eliyahu](https://github.com/YairEliyahu/)
* **Liav Maman** - *Software Engineer Student at Shamoon College of Engenering - SCE* - [Liav Maman](https://github.com/liav11maman/)