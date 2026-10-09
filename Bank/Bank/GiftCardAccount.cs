namespace bank;

/// <summary>
/// Представляет подарочный банковский счёт с ежемесячным пополнением.
/// </summary>
public class GiftCardAccount : BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="GiftCardAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца подарочного счёта.</param>
    /// <param name="initialBalance">Начальный баланс.</param>
    /// <param name="monthlyDeposit">Сумма автоматического ежемесячного пополнения.</param>
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0)
        : base(name, initialBalance)
        => _monthlyDeposit = monthlyDeposit;

    /// <summary>
    /// Выполняет ежемесячное автоматическое начисление подарочного депозита.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly deposit");
        }
    }

    /// <summary>
    /// Возвращает строковое представление подарочного счёта, включая величину ежемесячного бонуса.
    /// </summary>
    /// <returns>Строка с базовой информацией и суммой ежемесячного пополнения.</returns>
    public override string ToString()
        => base.ToString() + $"monthly deposit: {_monthlyDeposit}";
}
