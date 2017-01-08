using System;
using Enterprise.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Enterprise.SaaS.Identity
{
    public class MultitenancyRoleClaim : MultitenancyRoleClaim<string,string>
    {
        
    }

    public class MultitenancyRoleClaim<TKey, TTenantKey> : IdentityRoleClaim<TKey>, ITenant<TTenantKey> where TKey : IEquatable<TKey>
    {
        public TTenantKey TenantId { get; set; }
    }
}