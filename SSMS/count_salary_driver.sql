CREATE PROCEDURE CalculateTotalSalary
AS
BEGIN
    DECLARE @totalSalary DECIMAL(10, 2);

    SELECT @totalSalary = SUM(salary) FROM driver;

    SELECT @totalSalary AS TotalSalary;
END;