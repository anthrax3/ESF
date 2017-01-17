using System;
using Enterprise.Domain;

namespace Enterprise.Application
{
    public class App : BaseEntity<Guid,string>
    {
    }

    public class Edition : BaseEntity<Guid, string>
    {
        public string AppId { get; set; }
        public string Version { get; set; }
        public DateTime? LastUpdated { get; set; }
        public virtual App App { get; set; }
    }

    public class Client : BaseEntity<Guid, string>
    {
        public string AppId { get; set; }
        public string Version { get; set; }
        public DateTime? LastUpdated { get; set; }
        public virtual App App { get; set; }
    }

    public class Feature : BaseEntity<Guid, string>
    {
        public string AppId { get; set; }

        public virtual App App { get; set; }
    }

    public class EditionFeature
    {
        public string EditionId { get; set; }
        public string FeatureId { get; set; }
    }

}
