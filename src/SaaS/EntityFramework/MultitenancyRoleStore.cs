using System;
using System.Security.Claims;
using Enterprise.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.SaaS.Identity.EntityFramework
{
    public class MultitenancyRoleStore<TRole, TContext, TKey, TTenantKey, TUserRole, TRoleClaim> : RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>
        where TRole :  MultitenancyRole<TKey,TTenantKey> 
        where TContext : DbContext 
        where TKey : IEquatable<TKey> 
        where TUserRole : MultitenancyUserRole<TKey, TTenantKey>, new()
        where TRoleClaim : MultitenancyRoleClaim<TKey,TTenantKey>, new()
    {
        public MultitenancyRoleStore(TContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="ITenant{TTenantKey}.TenantId"/> to be used in queries.
        /// </summary>
        public  TTenantKey TenantId { get; set; }

        #region Overrides of RoleStore<TRole,TContext,TKey,TUserRole,TRoleClaim>

        protected override TRoleClaim CreateRoleClaim(TRole role, Claim claim)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}