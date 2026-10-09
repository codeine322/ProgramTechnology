namespace bank;

/// <summary>
/// Представляет кредитный счёт (кредитную линию) с возможностью уходить в минус до установленного лимита.
/// </summary>
public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="LineOfCreditAccount"/>.
    /// </summary>
    /// <param name="name">Имя владельца кредитного счёта.</param>
    /// <param name="initialBalance">Начальный баланс.</param>
    /// <param name="creditLimit">Максимально допустимый кредитный лимит (записывается со знаком минус).</param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
    {
    }

    /// <summary>
    /// Списывает ежемесячные проценты за использование кредитных средств, если баланс отрицательный.
    /// </summary>
    public override void PerformMonthAndTransactions()
    {
        if (Balance < 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge monthly interest");
        }
    }

    /// <summary>
    /// Переопределяет проверку превышения лимита: вместо исключения генерирует штрафную транзакцию овердрафта.
    /// </summary>
    /// <param name="isOverdrawn">Флаг, указывающий на уход баланса ниже установленного лимита.</param>
    /// <returns>Новая транзакция штрафа за овердрафт в размере 20 единиц, либо null.</returns>
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;
}
