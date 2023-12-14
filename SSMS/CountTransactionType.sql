CREATE PROCEDURE CountTransactionsByType
    @transactionType varchar(25)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS TransactionCount
    FROM transation
    WHERE confirm = @transactionType;
END
