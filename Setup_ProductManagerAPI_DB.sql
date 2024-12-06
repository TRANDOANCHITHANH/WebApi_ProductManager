CREATE DATABASE ProductManagerAPI
GO
USE ProductManagerAPI
GO
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY, 
    ProductName NVARCHAR(100) NOT NULL,     
    Price DECIMAL(18, 2) NOT NULL,          
    StockQuantity INT NOT NULL              
);
GO