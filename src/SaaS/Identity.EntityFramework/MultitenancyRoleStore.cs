using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.SaaS.Identity.EntityFramework
{
    public class MultitenancyRoleStore<TRole, TContext, TKey, TTenantKey, TUserRole, TRoleClaim> : RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>
        where TRole :  MultitenancyRole<TKey,TTenantKey, TUserRole, TRoleClaim> 
        where TContext : DbContext 
        where TKey : IEquatable<TKey> 
        where TUserRole : MultitenancyUserRole<TKey, TTenantKey>
        where TRoleClaim : MultitenancyRoleClaim<TKey,TTenantKey>
    {
        public MultitenancyRoleStore(TContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        #region Overrides of RoleStore<TRole,TContext,TKey,TUserRole,TRoleClaim>

        protected override TRoleClaim CreateRoleClaim(TRole role, Claim claim)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}