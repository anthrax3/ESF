using Enterprise.Application;
using Enterprise.Domain;

namespace Enterprise.SaaS.Application
{
    public class TenantSystemSetting : SystemSetting,ITenant
    {
        #region Implementation of ITenant<string>

        public string TenantId { get; set; }

        #endregion
    }
}