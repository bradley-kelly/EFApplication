USE [CustomerData]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateCustomers]
	@Firstname VARCHAR(30),
	@CustomerID int
AS
BEGIN
update Customers
SET Firstname = @Firstname
WHERE CustomerID = @CustomerID
END