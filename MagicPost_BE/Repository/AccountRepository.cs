using MagicPost_BE.Data;
using MagicPost_BE.Interfaces;
using MagicPost_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicPost_BE.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.Where(p => p.AccountId == id).FirstOrDefault();
        }

        public Account GetAccountByName(string name)
        {
            throw new NotImplementedException();
        }

        public ICollection<Account> GetAccounts()
        {
            return _context.Accounts.OrderBy(p => p.AccountId).ToList();
        }

        public ICollection<Account> GetAccountsByOffice(int officeId)
        {
            return _context.Accounts.Where(e => e.WorkAt.OfficeId == officeId).ToList();
        }

        public ICollection<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
