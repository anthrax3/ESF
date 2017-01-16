using System;
using System.Linq.Expressions;
using Enterprise.Domain;
using Enterprise.SaaS;
using Nofdev.Core.SOA;

namespace Enterprise.Integration.Nofdev
{
    public class TenantChecker : ITenantChecker
    {
        #region Implementation of ITenantChecker

        public void AssignTenantId(object entity)
        {
            var obj = entity as ITenant;
            if(obj != null)
                obj.TenantId = ServiceContext.Current.User.TenantId;
        }

        public void CheckTenantId(object entity)
        {
            var obj = entity as ITenant;
            if(obj?.TenantId != ServiceContext.Current.User.TenantId)
                throw new UnauthorizedAccessException("Tenant ID unmatched.");
        }

        public Expression<Func<TEntity, bool>> MakeExpression<TEntity>()
        {
            return ServiceContext.Current.User.MakeExpression<TEntity>();
        }

        #endregion
    }
}
