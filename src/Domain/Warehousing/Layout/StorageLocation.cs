namespace Enterprise.Domain.Warehousing.Layout
{
    public abstract class StorageLocation : BaseEntity
    {
        public virtual StorageArea StorageArea { get; set; }
        public int StorageAreaId { get; set; }
        public virtual Passage Passage { get; set; }
        public int PassageId { get; set; }
        public int Ordinal { get; set; }
    }
}