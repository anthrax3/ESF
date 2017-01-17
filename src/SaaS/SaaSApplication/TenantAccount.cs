using System;

namespace Enterprise.SaaS.Application
{
    public class TenantAccount
    {
        public int Id { get; set; }
        public string TenantId { get; set; }
        public decimal Balance { get; set; }
        public decimal CumulativeAmount { get; set; }
        /// <summary>
        /// 礼金
        /// </summary>
        public decimal Gift { get; set; }
        public int Rank { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class TenantAccountTransaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Action { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal Balance { get; set; }
        public decimal Gift { get; set; }
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}