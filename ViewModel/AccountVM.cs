using BankApp.Models;

namespace BankApp.ViewModel
{
    public class AccountVM
    {
        public decimal Balance { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}
