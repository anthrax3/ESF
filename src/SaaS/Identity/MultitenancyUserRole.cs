using System;
using Enterprise.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Enterprise.SaaS.Identity
{
    public class MultitenancyUserRole : MultitenancyUserRole<string, string>
    {
        
    }

    public class MultitenancyUserRole<TKey, TTenantKey> : IdentityUserRole<TKey>, ITenant<TTenantKey> where TKey : IEquatable<TKey>
    {
        public TTenantKey TenantId { get; set; }
    }

   
}