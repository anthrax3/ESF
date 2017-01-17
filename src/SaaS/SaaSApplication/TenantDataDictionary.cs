using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.Application;
using Enterprise.Domain;

namespace Enterprise.SaaS.Application
{
    public class TenantDataDictionary : DataDictionary,ITenant
    {
        #region Implementation of ITenant<string>

        public string TenantId { get; set; }

        #endregion
    }

    public class TenantDataItem : DataItem, ITenant
    {
        #region Implementation of ITenant<string>

        public string TenantId { get; set; }

        #endregion
    }
}
