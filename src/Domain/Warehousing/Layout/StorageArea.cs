using System.Collections.Generic;

namespace Enterprise.Domain.Warehousing.Layout
{
    public abstract class StorageArea : BaseEntity
    {
        public virtual Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }
        public virtual StorageType StorageType { get; set; }

        public int TypeId { get; set; }

        /// <summary>
        /// 下属库位
        /// </summary>
        public ICollection<StorageLocation> Locations { get; set; }
    }
}