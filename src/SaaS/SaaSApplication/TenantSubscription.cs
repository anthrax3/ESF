using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise.SaaS.Application
{
    public class TenantSubscription
    {
        public string TenantId { get; set; }
        public string AppId { get; set; }
        public string EditionId { get; set; }
        public DateTime SubscribedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
