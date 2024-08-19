namespace BankApp.Models
{
    public class AccountModel
    {
        public decimal Balance { get; private set; }

        public AccountModel(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Deposit(decimal amount, decimal exchangeRate)
        {
            Balance += amount / exchangeRate;
        }

        public void Withdraw(decimal amount, decimal exchangeRate)
        {
            Balance -= amount / exchangeRate;
        }
    }
}
