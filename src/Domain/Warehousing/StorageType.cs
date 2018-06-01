using System;
using Enterprise.Domain.Common;

namespace Enterprise.Domain.Warehousing
{
    public abstract class StorageType : StatefulModel<Guid,string>,IStorageTemperature
    {
        public string Name { get; set; }

        #region Implementation of IStorageTemperature

        public bool IsTemperatureLimited { get; set; }
        public decimal? MinTemperature { get; set; }
        public decimal? MaxTemperature { get; set; }
        public TemperatureUnit TemperatureUnit { get; set; } = TemperatureUnit.Centigrade;

        #endregion

        public StorageSecurityLevel SecurityLevel { get; set; }

        public byte QualityGrade { get; set; }
    }



}
