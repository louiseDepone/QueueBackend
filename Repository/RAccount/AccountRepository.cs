using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.RAccount;

public class AccountRepository(QueueDbContext context) : IAccountRepository
{
    private readonly QueueDbContext _context = context;
    public void AddAccount(Account account)
    {
        _context.Account.Add(account);
        _context.SaveChanges();
    }

    public void DeleteAccount(Account account)
    {
        _context.Account.Remove(account);
        _context.SaveChanges();
    }

    public Account? GetAccountById(int accountId)
    {
        return _context.Account.Include(
            a => a.Department
        ).Include(
            a => a.Role
        ).FirstOrDefault(a => a.Id == accountId);
    }

    public List<Account> GetAccounts()
    {
        return _context.Account.Include(
            a => a.Department
        ).Include(
            a => a.Role
        ).ToList();
    }

    public List<Account> GetAccountsByRole(int roleId)
    {
        return _context.Account.Where(a => a.RoleId == roleId).Include(
            a => a.Department
        ).Include(
            a => a.Role
        ).ToList();
    }

    public void UpdateAccount(Account account)
    {
        _context.Account.Update(account);
        _context.SaveChanges();
    }
}
