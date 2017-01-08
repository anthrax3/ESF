using Enterprise.Domain;

namespace Enterprise.SaaS.Identity
{
    public class OrganizationUnit<T,TUserKey> : MutableModel<T,TUserKey>
    {
        public T ParentId { get; set; }
    }
}
