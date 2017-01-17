using Enterprise.Application;
using Enterprise.Domain;

namespace Enterprise.SaaS.Application
{
    public class TenantAppSetting : AppSetting,ITenant
    {
        #region Implementation of ITenant<string>

        public string TenantId { get; set; }

        #endregion
    }
}