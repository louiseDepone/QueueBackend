using Backend.DTO;
using Backend.Models;
using Backend.Repository.RDepartment;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Department;

public class DepartmentRepository(QueueDbContext context): IDepartmentRepository
{
    private readonly QueueDbContext _context = context;

    public void AddDepartment(Models.Department newDepartmen)
    {
        _context.Department.Add(newDepartmen);
        _context.SaveChanges();
    }

    public void UpdateDepartment(Models.Department department)
    {
        _context.Department.Update(department);
        _context.SaveChanges();
    }

    public void DeleteDepartment(Models.Department department)
    {
        
        _context.Department.Remove(department);
        _context.SaveChanges();
    }

    public Models.Department? GetDepartmentById(int departmentId)
    {
        var department = _context.Department.FirstOrDefault(x => x.Id == departmentId);
        return department;
    }

    public Models.Department? GetDepartmentByName(string departmentName)
    {
        var department = _context.Department.FirstOrDefault(d => d.Name.ToLower() == departmentName.ToLower() );
        return department;
    }

    public List<Models.Department> GetAllDepartments()
    {
        return _context.Department.ToList();
    }

    public List<Account> GetAccountsByDepartmentId(int departmentId)
    {
        var accounts = _context.Account.Where(a => a.DepartmentId == departmentId).ToList();
        return accounts;
    }
}