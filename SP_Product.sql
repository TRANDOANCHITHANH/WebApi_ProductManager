-- sp_GetAllProducts
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT ProductId, ProductName, Price, StockQuantity FROM Products
END

-- sp_GetProductById
CREATE PROCEDURE sp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT ProductId, ProductName, Price, StockQuantity 
    FROM Products 
    WHERE ProductId = @ProductId
END

