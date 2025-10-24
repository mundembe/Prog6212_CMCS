-- Create the database
CREATE DATABASE Contract_Monthly_Claim;
GO

USE Contract_Monthly_Claim;
GO

-- Create Admin_ table
CREATE TABLE Admin_ (
    Admin_ID INT IDENTITY(1,1) PRIMARY KEY,
    First_Name NVARCHAR(100),
    LastName NVARCHAR(100),
    Admin_Address NVARCHAR(200),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Username NVARCHAR(50),
    Admin_Password NVARCHAR(100)
);
GO

-- Create Lecturer table
CREATE TABLE Lecturer (
    Lecturer_ID INT IDENTITY(1,1) PRIMARY KEY,
    First_Name NVARCHAR(100),
    LastName NVARCHAR(100),
    Lecturer_Address NVARCHAR(200),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Username NVARCHAR(50),
    Lecturer_Password NVARCHAR(100)
);
GO

-- Create Claim table
CREATE TABLE Claim (
    Claim_ID INT IDENTITY(1,1) PRIMARY KEY,
    Course NVARCHAR(100),
    Session_NUmber INT,
    Hourly_Rate DECIMAL(10,2),
    Claim_Type NVARCHAR(50),
    Supportive_Document NVARCHAR(MAX),
    Lecturer_ID INT,
    FOREIGN KEY (Lecturer_ID) REFERENCES Lecturer(Lecturer_ID)
);
GO

-- Create Approval table
CREATE TABLE Approval (
    Approval_ID INT IDENTITY(1,1) PRIMARY KEY,
    Admin_ID INT,
    Claim_ID INT,
    Decision NVARCHAR(20),
    FOREIGN KEY (Admin_ID) REFERENCES Admin_(Admin_ID),
    FOREIGN KEY (Claim_ID) REFERENCES Claim(Claim_ID)
);
GO