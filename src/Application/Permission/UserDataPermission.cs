using Enterprise.Domain;

namespace Enterprise.Application.Permission
{
    public class UserDataPermission<TKey, TUserKey> : ImmutableModel<TKey, TUserKey>
    {
        public TUserKey UserId { get; set; }

        /// <summary>
        ///     key
        /// </summary>
        public string DataKey { get; set; }

        /// <summary>
        /// data items,split by '|'
        /// </summary>
        public string DataItems { get; set; }

    }
}
