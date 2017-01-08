using Enterprise.Application.Permission;

namespace ESF.SaaS.Application.Permission
{
    public class MultitenancyUserPermission : MultitenancyUserPermission<int, string, string, string>
    {
    }

    public class MultitenancyUserPermission<TKey, TUserKey, TPermission, TTenant> :
        UserPermission<TKey, TUserKey, TPermission>
    {
        public TTenant TenantId { get; set; }
    }
}