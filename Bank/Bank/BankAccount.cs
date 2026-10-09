using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace bank;

/// <summary>
/// Представляет базовый класс банковского счёта и управляет его операциями.
/// </summary>
public class BankAccount
{
    private readonly decimal _minimumBalance;
    private static int s_accountNumberSeed = 1000000000;

    /// <summary>
    /// Уникальный номер банковского счёта.
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// Имя владельца банковского счёта.
    /// </summary>
    public string Owner { get; private set; }

    /// <summary>
    /// Текущий баланс счёта, вычисляемый как сумма всех транзакций.
    /// </summary>
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in _allTransactions)
            {
                balance += transaction.Amount;
            }
            return balance;
        }
    }

    private List<Transaction> _allTransactions = new List<Transaction>();

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с нулевым минимальным балансом.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс при открытии счёта.</param>
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="BankAccount"/> с явным указанием лимита.
    /// </summary>
    /// <param name="name">Имя владельца счёта.</param>
    /// <param name="initialBalance">Начальный баланс при открытии счёта.</param>
    /// <param name="minimumBalance">Минимально допустимый баланс (лимит) для счёта.</param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
        _minimumBalance = minimumBalance;

        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.UtcNow, "initial balance");
    }

    /// <summary>
    /// Производит внесение (депозит) денежных средств на счёт.
    /// </summary>
    /// <param name="amount">Сумма пополнения. Должна быть положительной.</param>
    /// <param name="date">Дата операции.</param>
    /// <param name="note">Комментарий к операции.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Бросается, если <paramref name="amount"/> меньше нуля.
    /// </exception>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException
                (nameof(amount), "Amount of deposit must be positive");
        }

        var deposite = new Transaction(amount, date, note);
        _allTransactions.Add(deposite);
    }

    /// <summary>
    /// Производит снятие (списание) денежных средств со счёта.
    /// </summary>
    /// <param name="amount">Сумма списания. Должна быть положительной.</param>
    /// <param name="date">Дата операции.</param>
    /// <param name="note">Комментарий к операции.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Бросается, если <paramref name="amount"/> меньше или равен нулю.
    /// </exception>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Transaction? overdraftTransaction
            = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);

        _allTransactions.Add(withdrawal);

        if (overdraftTransaction is not null)
            _allTransactions.Add(overdraftTransaction);
    }

    /// <summary>
    /// Проверяет доступность лимита при снятии средств и формирует штрафную транзакцию при овердрафте.
    /// </summary>
    /// <param name="isOverdrawn">Флаг, указывающий, приведёт ли операция к превышению лимита.</param>
    /// <returns>Объект транзакции овердрафта, либо null, если превышения нет.</returns>
    /// <exception cref="InvalidOperationException">Вызывается, если на счёте недостаточно средств.</exception>
    protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
    {
        if (isOverdrawn)
        {
            throw new InvalidOperationException("Not sufficient rubls for this widthdrawal");
        }
        else
        {
            return default;
        }
    }

    /// <summary>
    /// Формирует текстовую выписку по истории всех транзакций счёта.
    /// </summary>
    /// <returns>Строка, содержащая таблицу истории операций.</returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();

        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"" +
                $"{item.Date.ToShortDateString()}\t" +
                $"{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }

    /// <summary>
    /// Выполняет регламентные финансовые операции, привязанные к концу месяца.
    /// </summary>
    public virtual void PerformMonthAndTransactions()
    {
    }

    /// <summary>
    /// Возвращает стандартизированное строковое представление текущего состояния счёта.
    /// </summary>
    /// <returns>Строка с типом, владельцем, номером и балансом счёта.</returns>
    public override string ToString()
    {
        return $"Type: {GetType().Name}\t" + $"Owner: {Owner}\t" + $"Number of account: {Number}\t" + $"Balance: {Balance}";
    }
}
