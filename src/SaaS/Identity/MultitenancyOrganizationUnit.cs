using Enterprise.Domain;

namespace Enterprise.SaaS.Identity
{
    public class MultitenancyOrganizationUnit : MultitenancyOrganizationUnit<string, string, string>
    {
        
    }

    public class MultitenancyOrganizationUnit<T,TUserKey, TTenant> : OrganizationUnit<T, TUserKey>,ITenant<TTenant>
    {
        #region Implementation of ITenant<TTenant>

        public TTenant TenantId { get; set; }

        #endregion
    }
}