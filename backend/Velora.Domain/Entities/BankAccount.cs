using System.Net.Sockets;

namespace Velora.Domain.Entities
{
    public class BankAccount : Entity
    {
        public string BankName { get; set; }

        public string BankAccountNumber { get; set; }

        public decimal Balance { get; set; }


        //Foreighn keys
        public Guid UserId { get; set; }
       


        //Navigation
        public User User { get; set; }

        public ICollection<Payment> Payments { get; set; }
        
        private BankAccount()
        {

        }
        public BankAccount(string bankName, string? bankAccountNumber, decimal balance, Guid userId)
        {
            BankName = bankName;
            BankAccountNumber = bankAccountNumber;
            Balance = balance;
            UserId = userId;
              
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Kwota nie moze byc ponizej 0");
            }

            Balance += amount;
        }

        public void WithDraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Kwota nie moze byc ponizej 0");
            }

            Balance -= amount;
        }

    }
}