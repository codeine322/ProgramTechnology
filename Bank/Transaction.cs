namespace bank;

/// <summary>
/// Представляет отдельную финансовую операцию (транзакцию) по счёту.
/// </summary>
public class Transaction
{
    /// <summary>
    /// Сумма операции. Положительная для зачислений, отрицательная для списаний.
    /// </summary>
    public decimal Amount { get; }

    /// <summary>
    /// Дата и время проведения финансовой операции.
    /// </summary>
    public DateTime Date { get; }

    /// <summary>
    /// Комментарий или примечание к финансовой операции.
    /// </summary>
    public string Note { get; }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Transaction"/>.
    /// </summary>
    /// <param name="amount">Сумма операции.</param>
    /// <param name="date">Дата проведения.</param>
    /// <param name="note">Комментарий к операции.</param>
    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Note = note;
    }
}
