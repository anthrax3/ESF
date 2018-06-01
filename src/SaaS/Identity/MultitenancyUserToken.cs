using System;
using Enterprise.Domain;
using Microsoft.AspNetCore.Identity;

namespace Enterprise.SaaS.Identity
{
    public class MultitenancyUserToken : MultitenancyUserToken<string, string>
    {
    }

    public class MultitenancyUserToken<TUserKey, TTenantKey> : IdentityUserToken<TUserKey>, ITenant<TTenantKey>
        where TUserKey : IEquatable<TUserKey>
    {
        public TTenantKey TenantId { get; set; }
    }
}