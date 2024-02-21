# SmartGarage

## Overview

SmartGarage [smartgarageproject.com](https://smartgarageproject.com) is a project designed to streamline garage operations for both service providers and customers. It allows users to manage vehicle visits, track service status, and perform various administrative tasks. Service providers can efficiently assign services to vehicles, while customers can monitor their vehicle's status and scheduled services.

## Features

- User authentication and authorization.
- Manage visits to the garage: add, remove, and update.
- Register vehicles to specific customers.
- Convert between over 170 currencies (e.g., EUR to BGN, USD, etc.) using an external API - [freecurencyapi.com](https://freecurrencyapi.com/).

## Technologies Used

- [Vue.js](https://vuejs.org/) for the frontend interface.
- Entity Framework Core for data access and management.
- [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16) for storing application data.
- [Azure](https://azure.microsoft.com/en-us) for hosting the application.
- Back-end hosted on [backend.smartgarageproject.com](https://backend.smartgarageproject.com)
- Custom domain purchased from [namecheap.com](https://www.namecheap.com/)
- User authentication and authorization mechanisms.
- JavaScript, HTML, and CSS for Front-end development.

## Installation Instructions

To run SmartGarage locally, follow these steps:

1. Clone the repository:
```bash
git clone https://github.com/yavor1516/SmartGarage
```

Set up the database:

1. Create a new SQL database.
```bash
Add-Migration Initial
Update-Database
```
2. Update the connection string in the project configuration to point to your database.

How to run the application:

1. Open the project in your preferred development environment.
2. Set up the necessary environment variables.
3. Run the application to start the local server.

## Usage

### For Customers:

1. Register for an account by providing your email on the registration page.
2. Check your email for a password sent to you.
3. Log in to your account using your email and the password received.
4. View your registered vehicles and their visit details.
5. Monitor the status of scheduled services.

### For Employees:

1. Log in to your account with appropriate permissions.
2. Assign vehicles to customers.
3. Schedule services for assigned vehicles.

## Contribution:

Contributions to SmartGarage are welcome!  
If you find any bugs, have feature requests, or want to contribute code, please open an issue or submit a pull request on GitHub.