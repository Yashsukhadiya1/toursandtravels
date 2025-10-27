# Tours and Travels - TripMate

A comprehensive travel booking and management system built with ASP.NET Core MVC, featuring tour bookings, admin dashboard, and real-time notifications.

## 📋 Description

TripMate is a full-featured travel booking platform that allows users to browse and book tours, while providing administrators with a complete management dashboard. The system includes real-time notifications, booking management, and a modern responsive interface.

### Key Features

- **Tour Booking System**: Browse and book various travel tours
- **Admin Dashboard**: Complete booking management with real-time notifications
- **Database Integration**: SQL Server with Entity Framework Core
- **Responsive Design**: Modern Bootstrap-based UI
- **Real-time Notifications**: Admin notifications for new bookings and status updates
- **Multi-currency Support**: INR, USD, EUR currency options
- **Booking Management**: Track booking status and customer information

## 🚀 Installation Steps

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or VS Code (recommended)
- **Note**: The application uses InMemory database by default (no SQL Server required)

### Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd toursandtravels
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Database Configuration** (Optional)
   - The application uses InMemory database by default (no setup required)
   - To use SQL Server, update `Program.cs` to use `UseSqlServer()` instead of `UseInMemoryDatabase()`
   - Ensure SQL Server LocalDB is installed for SQL Server option

4. **Build the Project**
   ```bash
   dotnet build
   ```

## 🏃‍♂️ How to Run the Project

### Method 1: Using .NET CLI

1. **Navigate to the project directory**
   ```bash
   cd "C:\Users\ysukh\Yash Main\5th Sem\Dotnet\toursandtravels"
   ```

2. **Run the application**
   ```bash
   dotnet run
   ```

3. **Open your browser** and navigate to:
   ```
   https://localhost:5001
   ```
   or
   ```
   http://localhost:5000
   ```

### Method 2: Using Visual Studio

1. Open the project in Visual Studio 2022
2. Press `F5` or click the "Start" button
3. The application will launch in your default browser

### Method 3: Using VS Code

1. Open the project folder in VS Code
2. Open the integrated terminal
3. Run `dotnet run`
4. Open the browser to the displayed URL

## 📱 Application Features

### For Users
- **Browse Tours**: View available travel packages
- **Book Tours**: Complete booking process with customer details
- **View Bookings**: Track your booking history
- **Currency Selection**: Choose between INR, USD, EUR

### For Administrators
- **Admin Dashboard**: Access via `/Admin/Bookings`
- **Booking Management**: View all customer bookings
- **Status Updates**: Change booking status (Pending/Confirmed/Cancelled/Completed)
- **Notifications**: Real-time notifications for new bookings
- **Customer Management**: View customer details and booking information

## 🗄️ Database Schema

The application uses the following main entities:

- **Tours**: Travel packages with destinations, pricing, and highlights
- **Bookings**: Customer bookings with status tracking
- **Flights**: Flight information (seeded data)
- **Hotels**: Hotel information (seeded data)
- **Notifications**: Admin notification system

## 🔧 Configuration

### Database Configuration
The application uses InMemory database by default, which automatically seeds with sample data on startup. No database setup is required.

### Sample Data Included
- **8 Flights**: Various domestic routes with different airlines
- **7 Hotels**: Hotels across major Indian cities with star ratings
- **5 Tours**: Popular Indian destinations including Golden Triangle, Goa, Kashmir, Kerala, and Leh Ladakh

## 📁 Project Structure

```
toursandtravels/
├── Controllers/          # MVC Controllers
│   ├── AdminController.cs
│   ├── BookingController.cs
│   └── ToursController.cs
├── Data/                # Database Context
│   └── TravelDbContext.cs
├── Models/              # Entity Models
│   ├── Booking.cs
│   ├── Flight.cs
│   ├── Hotel.cs
│   ├── Notification.cs
│   └── Tour.cs
├── Services/            # Business Logic Services
│   ├── DatabaseBookingService.cs
│   ├── DatabaseTourService.cs
│   └── ...
├── Views/               # Razor Views
│   ├── Admin/
│   ├── Booking/
│   └── Tours/
└── wwwroot/            # Static Files
```

## 🛠️ Technologies Used

- **Backend**: ASP.NET Core MVC 9.0
- **Database**: SQL Server with Entity Framework Core
- **Frontend**: Bootstrap 5.3, Bootstrap Icons
- **Architecture**: MVC Pattern with Service Layer
- **ORM**: Entity Framework Core 9.0

## 🎯 Usage Guide

### Making a Booking
1. Navigate to "Tours" from the main menu
2. Select a tour to view details
3. Click "Book Now" to start the booking process
4. Fill in customer details and number of travelers
5. Complete the booking

### Admin Management
1. Navigate to "Admin" from the main menu
2. View all bookings in the admin dashboard
3. Update booking status using the dropdown menus
4. Check notifications for new bookings
5. Manage customer bookings and status updates

## 🔍 Troubleshooting

### Common Issues

1. **SQL Server LocalDB Error**
   - **Solution**: The application now uses InMemory database by default
   - No SQL Server installation required
   - If you see LocalDB errors, the app will still work with InMemory database

2. **Build Errors**
   - Run `dotnet restore` to restore packages
   - Ensure .NET 9.0 SDK is installed
   - Check that all NuGet packages are properly restored

3. **Port Already in Use**
   - The application runs on ports 5000 (HTTP) and 5001 (HTTPS)
   - Change ports in `launchSettings.json` if needed

4. **Entity Framework Warnings**
   - Decimal precision warnings are normal and don't affect functionality
   - The application includes proper decimal precision configuration

## 📝 License

This project is created for educational purposes as part of a .NET course assignment.

## 👨‍💻 Developer

Created as part of 5th Semester .NET coursework.

---

**Happy Traveling with TripMate! ✈️🏖️🗻**
