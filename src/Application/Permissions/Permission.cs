using System;
using Enterprise.Domain;

namespace Enterprise.Application.Permissions
{
    public class Permission : BaseEntity<Guid,string>
    {
        public string AppId { get; set; }

        public virtual App App { get; set; }
    }
}
