CREATE PROCEDURE CountDriverWithoutBus
AS
BEGIN
    SET NOCOUNT ON;
    SELECT COUNT(*) AS CountNullIdBus FROM driver WHERE id_bus IS NULL;
END
