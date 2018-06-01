using System;
using Enterprise.Domain;
using Microsoft.AspNetCore.Identity;

namespace Enterprise.SaaS.Identity
{
    public class MultitenancyUserClaim : MultitenancyUserClaim<string, string>
    {
    }

    public class MultitenancyUserClaim<TUserKey, TTenantKey> : IdentityUserClaim<TUserKey>, ITenant<TTenantKey>
        where TUserKey : IEquatable<TUserKey>
    {
        public TTenantKey TenantId { get; set; }
    }
}