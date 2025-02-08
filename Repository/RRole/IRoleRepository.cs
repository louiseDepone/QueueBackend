using System;
using Backend.Models;

namespace Backend.Repository.RRole;

public interface IRoleRepository
{
    void AddRole(Role role);
    void UpdateRole(Role role);
    void DeleteRole(Role role);
    Role? GetRoleById(int roleId);
    List<Role> GetRoles();

}
