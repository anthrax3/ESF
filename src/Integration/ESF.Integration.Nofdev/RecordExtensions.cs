using System;
using Enterprise.Domain;
using Nofdev.Core.SOA;

namespace ESF.Integration.Nofdev
{
    public static class RecordExtensions
    {
        public static void SetCreationInfo(this ICreationInfo model)
        {
            model.CreatedBy = ServiceContext.Current.User?.UserId;
            model.CreatedDate = DateTime.Now;
        }

        public static void SetUpdatingInfo(this IUpdatingInfo model)
        {
            model.UpdatedBy = ServiceContext.Current.User?.UserId;
            model.UpdatedDate = DateTime.Now;
        }
    }
}
