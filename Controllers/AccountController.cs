using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace BankApp.Controllers
{
    public class AccountController : Controller
    {
        private static AccountModel account = new AccountModel(1000.00m); // Initial balance
        private static List<Currency> currencies = new List<Currency>
        {
            new Currency { Name = "CAD", ExchangeRate = 1.00m },
            new Currency { Name = "USD", ExchangeRate = 0.50m },
            new Currency { Name = "MXN", ExchangeRate = 10.00m },
            new Currency { Name = "EURO", ExchangeRate = 0.25m }
        };

        public IActionResult Index()
        {
            var model = new AccountVM()
            {
                Balance = account.Balance,
                Currencies = currencies
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Operation(string operation, decimal amount, string currency)
        {
            var selectedCurrency = currencies.FirstOrDefault(c => c.Name == currency);

            if (selectedCurrency == null)
            {
                return BadRequest("Invalid currency selected.");
            }

            if (operation == "deposit")
            {
                account.Deposit(amount, selectedCurrency.ExchangeRate);
            }
            else if (operation == "withdraw")
            {
                account.Withdraw(amount, selectedCurrency.ExchangeRate);
            }
            else
            {
                return BadRequest("Invalid operation selected.");
            }

            return RedirectToAction("Index");
        }
    }
}
