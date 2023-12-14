CREATE PROCEDURE CountDriversWithoutBus
AS
BEGIN
    DECLARE @totalDriver INT;

    SELECT @totalDriver = SUM(price)
    FROM ticket
    WHERE id_bus = "";

    SELECT @totalDriver AS TotalPrice;
END;