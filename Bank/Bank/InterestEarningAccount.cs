using System.Security.Cryptography.X509Certificates;

namespace bank;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance)
        : base(name, initialBalance)

    { }

    public override void PerformMonthAndTransactions()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}