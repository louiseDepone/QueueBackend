using System;
using Backend.DTO;
using Backend.Models;
using Backend.Repository.RRole;

namespace Backend.Service.SRole;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    public void AddRole(CreateRoleDTO role)
    {
        try

        {
            var newRole = new Role
            {
                Name = role.Name
            };
            _roleRepository.AddRole(newRole);
        }
        catch (System.Exception)
        {

            throw;
        }

        
    }

    public void DeleteRole(int roleId)
    {
        var role = GetRoleById(roleId);
        _roleRepository.DeleteRole(role);

    }

    public Role? GetRoleById(int roleId)
    {
        try
        {
            var role = _roleRepository.GetRoleById(roleId);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            return role;
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public List<Role> GetRoles()
    {
        try
        {
            return _roleRepository.GetRoles();
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public void UpdateRole(CreateRoleDTO role, int roleId)
    {
        var roleToUpdate = _roleRepository.GetRoleById(roleId);

        roleToUpdate.Name = role.Name;
        _roleRepository.UpdateRole(roleToUpdate);

    }

}
