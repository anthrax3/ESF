using Enterprise.Domain;

namespace Enterprise.SaaS.Identity
{
    public class UserOrganization<T, TUserKey, TOrgKey> : ImmutableModel<T,TUserKey>
    {
        public TUserKey UserId { get; set; }
        public TOrgKey OrganizationUnitId { get; set; }
    }
}