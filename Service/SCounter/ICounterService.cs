using System;
using Backend.DTO;
using Backend.Models;

namespace Backend.Service.SCounter;

public interface ICounterService
{
    void AddCounter(CreateCounterDTO counter);
    void UpdateCounter(CreateCounterDTO counter, int id);
    void DeleteCounter( int id);
    Counter UpdateCounterAvailability(int id, bool status);
    Counter? GetCounterById(int id);

    List<Counter> GetCounters();
    
    List<Counter> GetCounterByDepartmentId(int departmentId);
    
    Counter GetCounterByNameAndLocation(string name, string location, int departmentId);
    List<Counter> GetCounterByLocation(int departmentId, string location);

    void UpdateCounterTicket(int counterId, int? ticketId);
}
