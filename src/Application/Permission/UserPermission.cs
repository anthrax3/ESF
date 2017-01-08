using Enterprise.Domain;

namespace Enterprise.Application.Permission
{
    public class UserPermission<TKey, TUserKey, TPermission> : MutableModel<TKey, TUserKey>
    {
        /// <summary>
        ///     permission code
        /// </summary>
        public string Code { get; set; }

        public TUserKey UserId { get; set; }

        public TPermission PermissionId { get; set; }

        public bool IsGranted { get; set; }
    }
}