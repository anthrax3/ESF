using Enterprise.Domain;

namespace Enterprise.SaaS.Identity
{
    public class MultitenancyAuditLog : MultitenancyAuditLog<string, string, string>
    {
        
    }

    public class MultitenancyAuditLog<T, TUserKey,TTenant> : AuditLog<T, TUserKey>, ITenant<TTenant>
    {
        #region Implementation of ITenant<TTenant>

        public TTenant TenantId { get; set; }

        #endregion
    }
}
