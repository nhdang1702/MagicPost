using MagicPost_BE.Models;

namespace MagicPost_BE.Interfaces
{
    public interface IAccountRepository
    {
        ICollection<Account> GetAllAccounts();

        ICollection<Account> GetAccountsByOffice(int OfficeId);

        Account GetAccountById(int id);

        Account GetAccountByName(string name);
    }
}
