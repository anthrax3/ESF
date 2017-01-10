namespace Enterprise.Application.Permissions
{
    public class RolePermission<TKey, TRoleKey, TPermission, TUserKey>  : PermissionRelation<TKey, TRoleKey, TPermission, TUserKey>
    {
        public TRoleKey RoleId => ReferenceId;

    }
}