using Enterprise.Application.Permissions;
using Enterprise.Domain;

namespace Enterprise.SaaS.Application.Permission
{
    public class MultitenancyRolePermission : MultitenancyRolePermission<int, string, string, string, string>,ICreationInfo,IUpdatingInfo
    {
    }

    public class MultitenancyRolePermission<TKey, TRoleKey, TPermission, TTenant, TUserKey> :
        RolePermission<TKey, TRoleKey, TPermission, TUserKey>
    {
        public TTenant TenantId { get; set; }
    }
}