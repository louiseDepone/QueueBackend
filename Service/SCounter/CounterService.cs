using System;
using Backend.DTO;
using Backend.Models;
using Backend.Repository.RCounter;
using Backend.Service.SDerpartment;

namespace Backend.Service.SCounter;

public class CounterService(ICounterRepository counterRepository,
IDepartmentService departmentService
): ICounterService
{
    private readonly ICounterRepository _counterRepository = counterRepository;
    private readonly IDepartmentService _departmentService = departmentService;

    public void UpdateCounterTicket(int counterId, int? ticketId)
    {
        try
        {
                var counter = GetCounterById(counterId);
                counter.CurrentTicketId = ticketId;
                _counterRepository.UpdateCounter(counter);
            
        }
        catch (Exception e)
        {
            
            throw;
        }
    }


    public void AddCounter(CreateCounterDTO counter)
    {
        try
        {
            // CHECK IF DPEARTMENT iD IS VALID
            _departmentService.GetDepartmentById(counter.DepartmentId);
            
            // get the counter by location
            var counterName = GetCounterByLocation(counter.DepartmentId, counter.Location).Where(c => c.Name == counter.Name);
            if (counterName.Count() > 0)
            {
                throw new Exception("Counter already exists");
            }

            Counter newCounter = new()
            {
                Name = counter.Name,
                Location = counter.Location,
                DepartmentId = counter.DepartmentId,
                Type = counter.Type
            };

            _counterRepository.AddCounter(newCounter);

        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public void UpdateCounter(CreateCounterDTO counter, int id)
    {
        try
        {
            var counterToUpdate = GetCounterById(id);
            // CHECK IF DPEARTMENT iD IS VALID
            _departmentService.GetDepartmentById(counter.DepartmentId);
           
            var counterName = GetCounterByLocation(counter.DepartmentId, counter.Location).Where(c => c.Name == counter.Name);
            if (counterName.Count() > 0)
            {
                throw new Exception("Counter already exists");
            }

            counterToUpdate.Name = counter.Name;
            counterToUpdate.Location = counter.Location;
            counterToUpdate.DepartmentId = counter.DepartmentId;
            counterToUpdate.Type = counter.Type;

            _counterRepository.UpdateCounter(counterToUpdate);
            
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public Counter UpdateCounterAvailability(int id, bool status){
        try
        {
            var counter = GetCounterById(id);
            counter.IsActive = status;
            return _counterRepository.UpdateCounter(counter);

        }
        catch (Exception e)
        {
            
            throw;
        }
    }


    public void DeleteCounter( int id)
    {
        try
        {
             var counter = GetCounterById(id); 

            _counterRepository.DeleteCounter(counter);       
            
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public Counter? GetCounterById(int id)
    {
        try
        {
            var counter = _counterRepository.GetCounterById(id);
            if (counter == null)
            {
                throw new Exception("Counter not found");
            }
            return counter;
            
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public List<Counter> GetCounters()
    {
        try
        {
            return _counterRepository.GetCounters();
            
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public List<Counter> GetCounterByDepartmentId(int departmentId)
    {
        try
        {
            // CHECK IF DPEARTMENT iD IS VALID
            _departmentService.GetDepartmentById(departmentId);
            return _counterRepository.GetCounterByDepartmentId(departmentId);
            
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public Counter GetCounterByNameAndLocation(string name, string location, int departmentId)
    {
        try
        {
            // CHECK IF DPEARTMENT iD IS VALID
            _departmentService.GetDepartmentById(departmentId);
            var counter = _counterRepository.GetCounterByNameAndLocation(name, location, departmentId);
            if (counter == null)
            {
                throw new Exception("Counter not found");
            }
            return counter;
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

    public List<Counter> GetCounterByLocation(int departmentId, string location)
    {
        try
        {
            // CHECK IF DPEARTMENT iD IS VALID
            _departmentService.GetDepartmentById(departmentId);
            return _counterRepository.GetCounterByLocation(departmentId, location);
            
        }
        catch (Exception e)
        {
            
            throw;
        }
    }

}
