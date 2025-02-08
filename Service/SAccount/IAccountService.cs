using System;
using Backend.DTO;
using Backend.Models;

namespace Backend.Service.SAccount;

public interface IAccountService
{
    Account GetAccountById(int accountId);
    List<Account> GetAccounts();
    List<Account> GetAccountsByRole(int roleId);
    Account AddAccount(CreateAccountDTO accountDTO);
    void UpdateAccount(CreateAccountDTO accountDTO, int accountId);
    void DeleteAccount(int accountId);
}
