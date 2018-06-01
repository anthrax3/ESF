using System.Collections.Generic;
using Enterprise.Domain.Common;

namespace Enterprise.Domain.Warehousing
{
    public abstract class Warehouse : BaseEntity
    {
        public int Type { get; set; }
        public int WarehouseNumber { get; set; }
        public AddressInfo Address { get; set; }
    }

}
