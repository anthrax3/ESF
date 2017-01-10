using System;
using Enterprise.Application.Permissions;
using Enterprise.Domain;

namespace Enterprise.SaaS.Application.Permission
{
    public class MultitenancyUserPermission : MultitenancyUserPermission<int, string, string, string>,ICreationInfo,IUpdatingInfo
    {
    }

    public class MultitenancyUserPermission<TKey, TUserKey, TPermission, TTenant> :
        UserPermission<TKey, TUserKey, TPermission>
    {
        public TTenant TenantId { get; set; }
    }
}