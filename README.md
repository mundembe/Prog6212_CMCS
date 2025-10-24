# Contract Monthly Claim Management System

A Windows Forms application for managing lecturer contract claims in an educational institution.

## Features

- **User Management**
  - Admin Registration and Login
  - Lecturer Registration and Login
  - Secure password validation with requirements for strong passwords

- **Claims Management**
  - Submit claims with course details
  - Track session numbers and hourly rates
  - Optional supporting document uploads
  - Claim approval workflow

- **Dashboard Features**
  - Admin Dashboard for managing claims and approvals
  - Lecturer Dashboard for submitting and tracking claims

## Technical Details

- **Framework**: .NET 8.0 Windows Forms
- **Data Storage**: Local JSON file storage
- **Architecture**: 
  - Models for data structures (Admin, Lecturer, Claim, Approval)
  - Services for data management (DataService)
  - Forms for user interface

## Getting Started

1. **Prerequisites**
   - .NET 8.0 SDK
   - Visual Studio 2022 or later (recommended)
   - Windows OS

2. **Installation**
   - Clone the repository
   - Open `POE_of_Prog.sln` in Visual Studio
   - Build and run the application

## Usage

### For Lecturers
1. Register a new account or login with existing credentials
2. Submit claims through the Lecturer Dashboard
3. Fill in required claim details:
   - Course information
   - Number of sessions
   - Hourly rate
   - Claim type
   - Upload supporting documents (optional)

### For Administrators
1. Register an admin account or login
2. Use the Admin Dashboard to:
   - View submitted claims
   - Approve or reject claims
   - Manage lecturer accounts

## Security Features

- Password requirements:
  - Minimum 8 characters
  - At least one uppercase letter
  - At least one lowercase letter
  - At least one number
  - At least one special character

- Input validation for:
  - Email addresses
  - Names (letters only)
  - Required fields

## Data Storage

The application uses local JSON file storage for:
- User accounts (Admin and Lecturer)
- Claims
- Approvals

Files are stored in the application's data directory with automatic initialization on first run.

## Testing

Unit tests are available in the `FinalProjectTest1` project to verify core functionality.

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.