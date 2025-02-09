using System;
using Backend.Models;

namespace Backend.Repository.RCounter;

public interface ICounterRepository
{
    
    Counter AddCounter(Counter counter);
    void UpdateCounter(Counter counter);
    void DeleteCounter(Counter counter);
    
    Counter? GetCounterById(int id);
    List<Counter> GetCounters();
    
    List<Counter> GetCounterByDepartmentId(int departmentId);
    
    Counter GetCounterByNameAndLocation(string name, string location, int departmentId);
    List<Counter> GetCounterByLocation(int departmentId, string location);

}
