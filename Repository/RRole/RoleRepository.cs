using System;
using Backend.Models;

namespace Backend.Repository.RRole;

public class RoleRepository(QueueDbContext context): IRoleRepository
{
    private readonly QueueDbContext _context = context;
    public void AddRole(Role role)
    {
        _context.Role.Add(role);
        _context.SaveChanges();
    }

    public void DeleteRole(Role role)
    {
        _context.Role.Remove(role);
        _context.SaveChanges();
    }

    public Role? GetRoleById(int roleId)
    {
        return _context.Role.FirstOrDefault(a => a.Id == roleId);
    }

    public List<Role> GetRoles()
    {
        return _context.Role.ToList();
    }

    public void UpdateRole(Role role)
    {
        _context.Role.Update(role);
        _context.SaveChanges();
    }
}
