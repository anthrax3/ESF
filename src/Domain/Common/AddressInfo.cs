namespace Enterprise.Domain.Common
{
    public struct AddressInfo : IAddressInfo
    {
        #region Implementation of IAddressInfo

        public string Address { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public int RegionId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        #endregion
    }

    public interface IAddressInfo
    {
         string Address { get; set; }
         string Contact { get; set; }
         string PhoneNumber { get; set; }
         string PostalCode { get; set; }
         int RegionId { get; set; }
         float X { get; set; }
         float Y { get; set; }
    }
}
