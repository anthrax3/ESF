using System;
using Enterprise.Domain;

namespace Enterprise.Application.Permissions
{
    public  class PermissionRelation<TKey, TRelatedKey, TPermission,TOperatorKey> : MutableModel<TKey, TOperatorKey>
    {
        public PermissionRelation()
        {
            CreatedDate = DateTime.Now;
        }

        /// <summary>
        ///     authorization code
        /// </summary>
        public string Code { get; set; }

        public TRelatedKey ReferenceId { get; set; }

        public TPermission PermissionId { get; set; }
    }
}