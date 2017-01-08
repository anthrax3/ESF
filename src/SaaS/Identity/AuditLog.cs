using Enterprise.Domain;

namespace Enterprise.SaaS.Identity
{
    public class AuditLog<T,TUser> : ImmutableModel<T, TUser>
    {
        public string ClientName { get; set; }
        public string ClientVersion { get; set; }
        public string ClientIP { get; set; }
        public string UserName { get; set; }
        public string CustomData { get; set; }
    }
}