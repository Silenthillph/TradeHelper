using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeHelper.EntityModel.Entities
{
    public class TradeInfo
    {
        public Guid Id { get; set; }
        public string PairCode { get; set; }
        public decimal Amount { get; set; }
        [Column(TypeName = "decimal(10, 4)")]
        public Nullable<decimal> BuyPrice { get; set; }
        [Column(TypeName = "decimal(10, 4)")]
        public Nullable<decimal> CellPrice { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> CloseDate { get; set; }
        public int Status { get; set; }
        public int PositionType { get; set; }
    }
}
