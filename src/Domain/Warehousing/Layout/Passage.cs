namespace Enterprise.Domain.Warehousing.Layout
{
    public abstract class Passage : BaseEntity
    {
        public virtual StorageArea StorageArea { get; set; }
        public int WarehouseId { get; set; }
        public int? StoreageAreaId { get; set; }
        public int Ordinal { get; set; }
    }
}