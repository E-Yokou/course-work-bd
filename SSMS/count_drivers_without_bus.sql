CREATE PROCEDURE CountDriversWithoutBus
AS
BEGIN
    DECLARE @totalDriver INT;

    SELECT @totalDriver = COUNT(id)
    FROM driver
    WHERE id_bus = null;

    SELECT @totalDriver AS TotalDriverCount;
END;
