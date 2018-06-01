using System;
using Enterprise.Domain;
using Microsoft.AspNetCore.Identity;

namespace Enterprise.SaaS.Identity
{
    public class MultitenancyRole : MultitenancyRole<string, string>
    {
        
    }

    public class MultitenancyRole<TKey, TTenantKey> : IdentityRole<TKey>, ITenant<TTenantKey> where TKey : IEquatable<TKey>
    {
        public TTenantKey TenantId { get; set; }
    }

   
}