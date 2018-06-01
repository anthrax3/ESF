namespace Enterprise.Domain.Warehousing
{
    /// <summary>
    /// 仓储用途
    /// </summary>
    public interface IStorageUsage
    {
        bool ForReceiving { get; set; }
        bool ForPicking { get; set; }
        bool ForSales { get; set; }
        bool ForReturns { get; set; }
        bool ForShipping { get; set; }
    }
}