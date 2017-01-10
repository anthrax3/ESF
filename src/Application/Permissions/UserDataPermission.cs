using System;
using Enterprise.Domain;

namespace Enterprise.Application.Permissions
{
    public class UserDataPermission<TKey, TUserKey> : MutableModel<TKey, TUserKey>
    {
        public UserDataPermission()
        {
            CreatedDate = DateTime.Now;
        }

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
