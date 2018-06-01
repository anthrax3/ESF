using System.ComponentModel;

namespace Enterprise.Domain.Warehousing
{
    public enum StockTaskTypes
    {
        /// <summary>
        ///     入库
        /// </summary>
       Inbound = 1,

        /// <summary>
        ///     移货
        /// </summary>
        Relocation = 2,

        /// <summary>
        ///     拣货
        /// </summary>
       Picking = 3,

        /// <summary>
        ///     出库
        /// </summary>
       Outbound = 4,

        /// <summary>
        ///     质量调整
        /// </summary>
      QualityAdjust = 5,

        /// <summary>
        ///     盘点
        /// </summary>
       Counting = 6
    }
}