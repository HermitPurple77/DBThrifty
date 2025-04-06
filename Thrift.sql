-- Create database
CREATE DATABASE ThriftTrack;
GO

-- Switch to database
USE ThriftTrack;
GO

-- Create Admins Table
CREATE TABLE Heads (
    Username VARCHAR(100) PRIMARY KEY,
    PasswordHash VARCHAR(100) NOT NULL
);

-- Create Customers table
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName VARCHAR(100) NOT NULL,
    Phone VARCHAR(15) UNIQUE NOT NULL
);

-- Create Products table
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50),
    Price DECIMAL(10,2) NOT NULL,
    Quantity INT NOT NULL
);

-- Create Orders table
CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(10,2) NOT NULL CHECK (Price >= 0),
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) CHECK (TotalAmount >= 0),
);

-- Create Payments table
CREATE TABLE Payments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NULL,
    OrderID INT UNIQUE NULL,
    PaymentMethod VARCHAR(50) NOT NULL CHECK (PaymentMethod IN ('Cash', 'Credit Card', 'PayPal')),
    AmountPaid DECIMAL(10,2) NOT NULL CHECK (AmountPaid >= 0),
    PaymentDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE SET NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE NO ACTION
);

-- Create OrderDetails
CREATE TABLE OrderDetails (
    OrderDetailID INT IDENTITY(1,1) PRIMARY KEY,
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    Price DECIMAL(10,2) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);



INSERT INTO Heads (Username, PasswordHash)
VALUES 
('admin', 'hash_pass1');

INSERT INTO Customers (CustomerName, Phone)
VALUES 
('Alice Johnson', '555-1234'),
('Bob Smith', '555-5678'),
('Charlie Davis', '555-9012');

Select * from Heads;
Select * from Customers;
Select * from Products;
Select * from Orders;
Select * from OrderDetails;

