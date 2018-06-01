using System.ComponentModel;

namespace Enterprise.Domain.Warehousing
{
    /// <summary>
    /// 库存移动类型
    /// </summary>
    public enum StockTransferTypes
    {
        /// <summary>
        /// 库位调整
        /// </summary>
        Relocation = 0,
        /// <summary>
        /// 上架
        /// </summary>
        Dock = 1,
        /// <summary>
        /// 下架
        /// </summary>
        Undock = 2,
        /// <summary>
        /// 质量调整
        /// </summary>
        QualityAdjust = 3
    }
}