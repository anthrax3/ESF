using System;
using Enterprise.Domain;
using Microsoft.AspNetCore.Identity;

namespace Enterprise.SaaS.Identity
{
    /// <summary>
    /// Minimal class for a <see cref="MultitenancyUser{TKey,TTenantKey,TLogin,TRole,TClaim}"/> with a
    /// <see cref="string"/> user <see cref="IdentityUser{TKey}.Id"/> and
    /// <see cref="MultitenancyUserLogin.TenantId"/>.
    /// </summary>
    public class MultitenancyUser :
        MultitenancyUser<string, string, MultitenancyUserLogin, MultitenancyUserRole, MultitenancyUserClaim>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultitenancyUser"/> class.
        /// </summary>
        public MultitenancyUser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultitenancyUser"/> class.
        /// </summary>
        /// <param name="userName">The <see cref="IdentityUser{TKey, TLogin, TRole, TClaim}.UserName"/> of the user.</param>
        public MultitenancyUser(string userName)
            : base(userName)
        {
        }
    }

    /// <summary>
    /// Class defining a multi-tenant user.
    /// </summary>
    /// <typeparam name="TKey">The type of <see cref="IdentityUser.Id"/> for a user.</typeparam>
    /// <typeparam name="TTenantKey">The type of <see cref="ITenant.TenantId"/> for a user.</typeparam>
    /// <typeparam name="TLogin">The type of user login.</typeparam>
    /// <typeparam name="TUserRole">The type of user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of user claim.</typeparam>
    public class MultitenancyUser<TKey, TTenantKey, TLogin, TUserRole, TUserClaim>
        : IdentityUser<TKey>, ITenant<TTenantKey>,
        IMutableModel<TKey,TKey> 
        where TLogin : MultitenancyUserLogin<TKey, TTenantKey>
        where TUserRole : MultitenancyUserRole<TKey,TTenantKey>
        where TUserClaim : MultitenancyUserClaim<TKey,TTenantKey>
        where TKey : IEquatable<TKey>
    {
        public MultitenancyUser()
        {
            CreatedDate = DateTime.Now;
        }

        public MultitenancyUser(string userName) : base(userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException(nameof(userName));
            CreatedDate = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the tenant.
        /// </summary>
        public TTenantKey TenantId { get; set; }

        public string TrueName { get; set; }

        #region Implementation of IImmutableModel<TKey>

        public DateTime CreatedDate { get; set; }
        public TKey CreatedBy { get; set; }

        #endregion

        #region Implementation of IMutableModel<TKey>

        public TKey UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        #endregion
    }
}
