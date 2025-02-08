using Backend.DTO;
using Backend.Models;

namespace Backend.Service.SDerpartment;

public interface IDepartmentService
{
    void  AddDepartment(CreateDepartmentDTO newDepartment);
    void UpdateDepartment(CreateDepartmentDTO department, int departmentId);
    void DeleteDepartment(int departmentId);
    
    Department GetDepartmentById(int departmentId);
    Department? GetDepartmentByName(string departmentName);
    List<Department> GetAllDepartments();
    
    List<Account> GetAccountsByDepartmentId(int departmentId);
}