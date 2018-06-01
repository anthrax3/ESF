using Enterprise.Domain.Common;

namespace Enterprise.Domain.Warehousing
{
    /// <summary>
    /// 仓储温度要求
    /// </summary>
    public interface IStorageTemperature
    {
        /// <summary>
        /// 是否限制
        /// </summary>
        bool IsTemperatureLimited { get; set; }

        decimal? MinTemperature { get; set; }
        decimal? MaxTemperature { get; set; }
        TemperatureUnit TemperatureUnit { get; set; }
    }
}