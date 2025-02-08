using System;
using Backend.DTO;
using Backend.Models;

namespace Backend.Service.SRole;

public interface IRoleService
{
    void AddRole(CreateRoleDTO role);
    void UpdateRole(CreateRoleDTO role, int roleId);
    void DeleteRole(int roleId);
    Role GetRoleById(int roleId);
    List<Role> GetRoles();

}
