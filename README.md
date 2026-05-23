# 📦 Postal Package Delivery System

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-5C2D91.svg?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

## 📌 Overview
The **Postal Package Delivery System** is a comprehensive desktop application built using **C#** and **WPF (Windows Presentation Foundation)**. Designed with a clean and user-friendly interface, this system streamlines the daily operations of a postal service, including customer management, order registration, advanced reporting, and package tracking. The application utilizes **SQL Server** for robust data management and includes comprehensive exception handling to ensure a smooth, crash-free user experience.

## 🛠️ Technologies & Tools
- **Language:** C# (Advanced Programming concepts)
- **UI Framework:** WPF (Windows Presentation Foundation)
- **Database:** Microsoft SQL Server
- **Version Control:** Git & GitHub
- **Data Export:** CSV generation for reports

## ✨ Key Features

### 👥 Employee Panel & Customer Registration
- Employees can register new customers using their Name, Last Name, National ID, Email, and Mobile Phone.
- **Automated Credentials:** The system generates a unique, random Username and Password for each new customer.
- **Email Notification:** Credentials are automatically emailed to the customer upon successful registration.

### 📦 Order Registration
- Orders are linked to the customer's National ID. If a customer is not found, the system redirects the employee to the registration page.
- Captures comprehensive order details: Sender Address, Receiver Address, and Content Type (Object, Document, Fragile).

### 📊 Advanced Order Reporting
- Powerful search and filtering capabilities across all employee orders.
- Filter by: Customer National ID, Package Type, Paid Price, Package Weight, and Delivery Type (Express/Normal).
- **Export to CSV:** Search results can be exported to a CSV file, automatically sorted by the order registration date.

### 🔍 Package Tracking & Status Management
- Employees can look up an order using its Order ID to view full details and current status.
- **Status Lifecycle:** `Registered` ➔ `Ready to send` ➔ `Sending` ➔ `Delivered`.
- Strict validation: Once a package is marked as `Delivered`, its status cannot be altered.

## 🌿 Git Workflow & Architecture
This project was developed collaboratively using a structured Git branching model:
- `main` branch: Contains production-ready code.
- `develop` branch: The main integration branch for ongoing development.
- `feature` branches: Each team member worked on specific features in individual branches created from `develop`, merging them back via Pull Requests.

## 🚀 How to Run

### Prerequisites
Before you begin, ensure you have the following installed on your machine:
- **Visual Studio 2022** (with `.NET desktop development` workload)
- **Microsoft SQL Server** (Express or Developer edition)
- **SQL Server Management Studio (SSMS)** (optional, for database management)

### Installation & Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YourUsername/Project_AP.git
   cd Project_AP
   ```

2. **Database Configuration:**
   - Open **Visual Studio** and load the `.sln` file.
   - Locate the `App.config` (or connection settings file) in the project.
   - Update the `ConnectionString` to match your local SQL Server instance:
     ```xml
     <connectionStrings>
       <add name="DefaultConnection" connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=PostalSystemDB;Integrated Security=True;" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```
   - *Note:* If the project uses Entity Framework, open the **Package Manager Console** and run `Update-Database` to generate the schema. Alternatively, run the provided `.sql` script in SSMS to create the tables.

3. **Email (SMTP) Configuration:**
   - The application automatically sends generated credentials to newly registered customers. 
   - Open the email service class or configuration file and enter your SMTP credentials (e.g., your Gmail address and App Password).

4. **Build and Run:**
   - Right-click on the Solution in Visual Studio and select **Restore NuGet Packages**.
   - Press `F5` or click the **Start** button to compile and launch the application.

## 📸 Screenshots
<img width="1196" height="823" alt="image" src="https://github.com/user-attachments/assets/58d7decc-b014-4510-a4f9-ea098a6b095d" />



## 🤝 Team Members
- Mohammad Mahdi SharafBayani
- Ali Gholami

Course: Advanced Programming (AP)
