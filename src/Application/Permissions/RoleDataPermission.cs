using System;
using Enterprise.Domain;

namespace Enterprise.Application.Permissions
{
    public class RoleDataPermission<TKey, TRoleKey> : MutableModel<TKey, TRoleKey>
    {
        public RoleDataPermission()
        {
            CreatedDate = DateTime.Now;
        }

        public TRoleKey RoleId { get; set; }

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
