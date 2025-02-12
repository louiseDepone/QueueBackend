# QueueBackend

**QueueBackend** is a queueing system built with .NET ASP Web API and PostgreSQL. The system is designed to manage and track queues in real-time, ensuring smooth operations and better user experience. This backend handles user requests, manages queue data, and sends email notifications when necessary.

## Features
- Real-time queue management and updates.
- User management with ticket generation.
- Integration with email services for notifications (via SMTP).
- PostgreSQL database for storing queue-related data.

## Technologies Used
- **Backend Framework:** .NET 9 ASP Web API
- **Database:** PostgreSQL
- **Email Service:** SMTP (Gmail)
- **Version Control:** Git/GitHub

## Configuration

Before you can run **QueueBackend**, you'll need to configure a few settings in the **appsettings.json** file. The primary configurations are for the PostgreSQL connection string and the SMTP email service for sending notifications.

### 1. Database Configuration
In the **appsettings.json** file, you will need to provide your PostgreSQL database connection string. This string contains the necessary details for connecting to your database, such as the host, database name, username, and password.

Example configuration:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=queue;Username=your_username;Password=your_password;Port=5432"
}
