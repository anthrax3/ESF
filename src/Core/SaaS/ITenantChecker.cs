using System;
using System.Linq.Expressions;

namespace Enterprise.SaaS
{
    public interface ITenantChecker
    {
        void AssignTenantId(object entity);

        void CheckTenantId(object entity);

        Expression<Func<TEntity, bool>> MakeExpression<TEntity>();
    }
}
