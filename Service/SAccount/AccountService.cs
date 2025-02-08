using System;
using Backend.DTO;
using Backend.Models;
using Backend.Repository.RAccount;
using Backend.Service.SDerpartment;
using Backend.Service.SRole;

namespace Backend.Service.SAccount;

public class AccountService(IAccountRepository accountRepository,
    IRoleService roleService,
    IDepartmentService departmentService
) : IAccountService
{
    private IAccountRepository _accountRepository = accountRepository;
    private IRoleService _roleService = roleService;
    private IDepartmentService _departmentService = departmentService;
    public Account GetAccountById(int accountId)
    {
        try
        {
            var account = accountRepository.GetAccountById(accountId);
            if (account == null)
            {
                throw new Exception("Account not found");
            }
            return account;
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public List<Account> GetAccounts()
    {
        return accountRepository.GetAccounts();
    }

    public List<Account> GetAccountsByRole(int roleId)
    {
        try
        {
            _roleService.GetRoleById(roleId);
            return accountRepository.GetAccountsByRole(roleId);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public Account AddAccount(CreateAccountDTO accountDTO)
    {
        if (
            string.IsNullOrEmpty(accountDTO.Email) ||
            string.IsNullOrEmpty(accountDTO.Password) ||
            string.IsNullOrEmpty(accountDTO.EmployeeId) ||
            string.IsNullOrEmpty(accountDTO.LastName) ||
            string.IsNullOrEmpty(accountDTO.FirstName))
        {
            throw new Exception("Invalid request");
        }

        _roleService.GetRoleById(accountDTO.RoleId);
        _departmentService.GetDepartmentById(accountDTO.DepartmentId);
        Account account = new Account()
        {
            Email = accountDTO.Email,
            FirstName = accountDTO.FirstName,
            LastName = accountDTO.LastName,
            Password = accountDTO.Password,
            RoleId = accountDTO.RoleId,
            DepartmentId = accountDTO.DepartmentId,
            EmployeeId = accountDTO.EmployeeId
        };
        _accountRepository.AddAccount(account);
        return account;
    }

    public void UpdateAccount(CreateAccountDTO accountDTO, int accountId)
    {
        if (
            string.IsNullOrEmpty(accountDTO.Email) ||
            string.IsNullOrEmpty(accountDTO.Password) ||
            string.IsNullOrEmpty(accountDTO.EmployeeId) ||
            string.IsNullOrEmpty(accountDTO.LastName) ||
            string.IsNullOrEmpty(accountDTO.FirstName))
        {
            throw new Exception("Invalid request");
        }
        Account account = GetAccountById(accountId);
        _roleService.GetRoleById(accountDTO.RoleId);
        _departmentService.GetDepartmentById(accountDTO.DepartmentId);

        account.Password = accountDTO.Password;
        account.Email = accountDTO.Email;
        account.FirstName = accountDTO.FirstName;
        account.LastName = accountDTO.LastName;
        account.RoleId = accountDTO.RoleId;
        account.EmployeeId = accountDTO.EmployeeId;
        account.DepartmentId = accountDTO.DepartmentId;
        _accountRepository.UpdateAccount(account);
    }

    public void DeleteAccount(int accountId)
    {
        Account account = GetAccountById(accountId);
        _accountRepository.DeleteAccount(account);

    }

}
