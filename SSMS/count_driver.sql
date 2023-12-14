CREATE PROCEDURE CalculateTicketPrice
AS
BEGIN
  SELECT @totalPrice = SUM(price)
    FROM ticket
    WHERE confirm = 'Подтверждено';
END;
