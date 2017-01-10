namespace Enterprise.Application.Permissions
{
    public class UserPermission<TKey, TUserKey, TPermission> : PermissionRelation<TKey, TUserKey,TPermission, TUserKey>
    {
        public TUserKey UserId => ReferenceId;
    }
}