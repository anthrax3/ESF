using Enterprise.Application.Permissions;
using Enterprise.Domain;

namespace Enterprise.SaaS.Application.Permission
{
    public class MultitenancyUserDataPermission : MultitenancyUserDataPermission<int, string, string>, ICreationInfo, IUpdatingInfo
    {
    }

    public class MultitenancyUserDataPermission<TKey, TUserKey, TTenant> :
        UserDataPermission<TKey, TUserKey>
    {
        public TTenant TenantId { get; set; }
    }
}