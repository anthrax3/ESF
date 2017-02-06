using Enterprise.Domain;

namespace Enterprise.SaaS.Identity
{
    public class AuditLog<TKey,TUser> : ImmutableModel<TKey, TUser>
    {
        public string ClientCode { get; set; }
        public string ClientVersion { get; set; }
        public string ClientIP { get; set; }
        public string UserName { get; set; }
        public string CustomData { get; set; }
    }
}