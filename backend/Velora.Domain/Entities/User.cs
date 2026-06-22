using System;
using System.Collections.Generic;
using System.Text;

namespace Velora.Domain.Entities
{
    public class User : Entity
    {
        //Personal
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        //Auth
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        //Navigation
        public ICollection<BankAccount> BankAccounts { get; set; }

        public ICollection<Payment> Payments { get; set; }
       

        private User()
        {

        }

        public User(string firstName, string? lastName, string email, string passwordHash)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
          
        }

     

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;

            UpdatedAt = UpdatedAt;
        }



    }
}
