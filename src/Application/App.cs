using System;
using Enterprise.Domain;

namespace Enterprise.Application
{
    public class App : BaseEntity
    {
    }

    public class Edition : BaseEntity
    {
        public int AppId { get; set; }
        public DateTime? LastUpdated { get; set; }
        public virtual App App { get; set; }
    }

    public class Feature
    {
        
    }

    public class EditionFeature
    {
        
    }

    public class TenantEdition
    {
        
    }
}
