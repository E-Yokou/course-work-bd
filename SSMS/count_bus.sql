CREATE PROCEDURE count_bus @totalBus INT OUTPUT
AS
BEGIN
  SELECT @totalBus = COUNT(*) FROM bus;
END;
