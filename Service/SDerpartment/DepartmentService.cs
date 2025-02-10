using Backend.DTO;
using Backend.Models;
using Backend.Repository.RDepartment;

namespace Backend.Service.SDerpartment;

public class DepartmentService(IDepartmentRepository departmentRepository): IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;
    
    public void AddDepartment(CreateDepartmentDTO newDepartment)
    {
        try
        {
            var department = new Department()
            {
                Name = newDepartment.Name
            };
            if (department.Name == null) throw new NullReferenceException("Department name cannot be null");
             var isExisting = _departmentRepository.GetDepartmentByName(department.Name);
             if (isExisting != null)
             {
                 throw new Exception("Department Name already exists");
             }
             
             _departmentRepository.AddDepartment(department);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }

    public void UpdateDepartment(CreateDepartmentDTO department, int departmentId)
    {
        try
        {
            GetDepartmentById(departmentId);
            var depChange = new Department()
            {
                Name = department.Name
            }; 
            var isExisting = _departmentRepository.GetDepartmentByName(depChange.Name);
            if (isExisting != null)
            {
                throw new Exception("Department Name already exists");
            }
            _departmentRepository.UpdateDepartment(depChange);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public void UpdateDepartmentCurrentNumber(int departmentId, long? currentNumber)
    {
        try
        {
            var department = GetDepartmentById(departmentId);
            department.CurrentTicketNumber = currentNumber;
            _departmentRepository.UpdateDepartment(department);
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public void DeleteDepartment(int departmentId)
    {
        var department = GetDepartmentById(departmentId);
        _departmentRepository.DeleteDepartment(department);
    }

    public Department GetDepartmentById(int departmentId)
    {
        try
        {
            var department = _departmentRepository.GetDepartmentById(departmentId);
            if (department == null) throw new Exception("Department ID is not existing");
            return department;
        }
        catch (Exception e)
        {
            throw;
        }
        
    }

    public Department? GetDepartmentByName(string departmentName)
    {
        try
        {
            var department = _departmentRepository.GetDepartmentByName(departmentName);
            if (department == null) throw new Exception("Department Name is not Existing ");
            return department;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public List<Department> GetAllDepartments()
    {
        return _departmentRepository.GetAllDepartments();
    }

    public List<Account> GetAccountsByDepartmentId(int departmentId)
    {
        return _departmentRepository.GetAccountsByDepartmentId(departmentId);
    }
}