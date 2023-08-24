using System;

public class BankAccount
{
    public string AccountNumber { get; }
    public decimal Balance { get; protected set; }

    public BankAccount(string accountNumber, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"{amount:C} deposited. New balance: {Balance:C}");
        }
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"{amount:C} withdrawn. New balance: {Balance:C}");
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient balance or invalid amount.");
            return false;
        }
    }
}

public sealed class SavingsAccount : BankAccount
{
    private decimal InterestRate { get; }

    public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate)
        : base(accountNumber, initialBalance)
    {
        InterestRate = interestRate;
    }

    public void CalculateInterest()
    {
        decimal interestAmount = Balance * InterestRate / 100;
        Deposit(interestAmount);
        Console.WriteLine($"Interest of {interestAmount:C} calculated and deposited.");
    }
}

public class Program
{
    public static void Main()
    {
        BankAccount account = new BankAccount("123456789", 1000);
        account.Deposit(500);
        account.Withdraw(200);

        SavingsAccount savingsAccount = new SavingsAccount("987654321", 2000, 2.5m);
        savingsAccount.Deposit(1000);
        savingsAccount.CalculateInterest();
        savingsAccount.Withdraw(500);
    }
}
