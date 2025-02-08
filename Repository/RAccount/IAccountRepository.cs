using System;
using Backend.Models;

namespace Backend.Repository.RAccount;

public interface IAccountRepository
{
    void AddAccount(Account account);
    void UpdateAccount(Account account);
    void DeleteAccount(Account account);
    Account? GetAccountById(int accountId);
    List<Account> GetAccounts();
    List<Account> GetAccountsByRole(int roleId);
}
