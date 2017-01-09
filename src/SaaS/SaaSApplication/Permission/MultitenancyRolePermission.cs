using Enterprise.Application.Permission;

namespace Enterprise.SaaS.Application.Permission
{
    public class MultitenancyRolePermission : MultitenancyRolePermission<int, string, string, string, string>
    {
    }

    public class MultitenancyRolePermission<TKey, TRoleKey, TPermission, TTenant, TUserKey> :
        RolePermission<TKey, TRoleKey, TPermission, TUserKey>
    {
        public TTenant TenantId { get; set; }
    }
}