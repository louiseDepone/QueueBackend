using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.RCounter;

public class CounterRepository(QueueDbContext context) : ICounterRepository
{
    private readonly QueueDbContext _context = context;

    public Counter AddCounter(Counter counter)
    {
        _context.Counter.Add(counter);
        _context.SaveChanges();
        return counter;
    }

    public Counter UpdateCounter(Counter counter)
    {
        _context.Counter.Update(counter);
        _context.SaveChanges();
        return counter;
    }

    public void DeleteCounter(Counter counter)
    {
        _context.Counter.Remove(counter);
        _context.SaveChanges();
    }

    public Counter? GetCounterById(int id)
    {
        return _context.Counter.Include(
            c => c.Department
        ).Include(
            c => c.CurrentTicket
        ).FirstOrDefault(c => c.Id == id);
    }

    public List<Counter> GetCounters()
    {
        return _context.Counter.Include(
            c => c.Department
        ).Include(
            c => c.CurrentTicket
        ).OrderBy(
            c => c.Id
        ).ToList();
    }

    public List<Counter> GetCounterByDepartmentId(int departmentId)
    {
        return _context.Counter.Where(c => c.DepartmentId == departmentId).Include(
            c => c.CurrentTicket
        ).Include(
            c => c.Department
        ).OrderBy(
            c => c.Id
        ).ToList();
    }

    public Counter GetCounterByNameAndLocation(string name, string location, int departmentId)
    {
        return _context.Counter.Include(
            c => c.Department
        ).Include(
            c => c.CurrentTicket
        ).FirstOrDefault(c => c.Name == name && c.Location == location && c.DepartmentId == departmentId);
    }

    public List<Counter> GetCounterByLocation(int departmentId, string location)
    {
        return _context.Counter.Where(c => c.DepartmentId == departmentId && c.Location == location).Include(
            c => c.Department
        ).Include(
            c => c.CurrentTicket
        ).ToList();
    }   
}
