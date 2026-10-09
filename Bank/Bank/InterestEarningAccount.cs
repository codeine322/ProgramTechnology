namespace bank;

/// <summary>
/// Представляет сберегательный счёт, на остаток которого начисляются проценты.
/// </summary>
public class InterestEarningAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="InterestEarningAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца сберегательного счёта.</param>
    /// <param name="initialBalance">Начальный баланс.</param>
    public InterestEarningAccount(string name, decimal initialBalance)
        : base(name, initialBalance)
    { }

    /// <summary>
    /// Начисляет ежемесячные проценты на остаток, если текущий баланс превышает порог в 500 единиц.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}
