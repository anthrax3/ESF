using System.ComponentModel;

namespace Enterprise.Domain.Warehousing
{
    /// <summary>
    /// 仓储安保级别
    /// </summary>
    public enum StorageSecurityLevel
    {
        /// <summary>
        /// 普通
        /// </summary>
        Common = 0,
        /// <summary>
        /// 专人管理
        /// </summary>
        Specific = 1
    }
}