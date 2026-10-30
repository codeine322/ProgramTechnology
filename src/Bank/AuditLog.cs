namespace bank;

public enum AuditOperationType
{
    Deposit,
    Withdrawal,
    Interest
}

public class AuditLog
{
    public string AccountNumber { get; }
    public AuditOperationType OperationType { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }

    public AuditLog(string accountNumber, AuditOperationType operationType, decimal amount, DateTime date)
    {
        AccountNumber = accountNumber;
        OperationType = operationType;
        Amount = amount;
        Date = date;

        WriteToLog();
    }

    private void WriteToLog()
    {
        Console.WriteLine($"[AUDIT] {Date:yyyy-MM-dd HH:mm:ss} | Счёт: {AccountNumber} | Тип: {OperationType} | Сумма: {Amount}");
    }
}
