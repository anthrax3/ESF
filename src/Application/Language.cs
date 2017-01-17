using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.Domain;

namespace Enterprise.Application
{
    public class Language : BaseEntity<Guid, string>
    {
        public string Icon { get; set; }
    }
}
