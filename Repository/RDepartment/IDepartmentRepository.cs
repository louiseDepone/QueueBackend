using Backend.DTO;
using Backend.Models;

namespace Backend.Repository.RDepartment;

public interface IDepartmentRepository
{
    void  AddDepartment(Models.Department newDepartment);
    void UpdateDepartment(Models.Department department);
    void DeleteDepartment(Models.Department department);
    
    Models.Department? GetDepartmentById(int departmentId);
    Models.Department? GetDepartmentByName(string departmentName);
    List<Models.Department> GetAllDepartments();
    
    List<Account> GetAccountsByDepartmentId(int departmentId);
}