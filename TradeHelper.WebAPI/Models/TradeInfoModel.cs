using System;
using TradeHelper.BLL.Common;
using TradeHelper.BLL.Utilities;

namespace TradeHelper.WebApi.Models
{
    public class TradeInfoModel
    {
        public TradeInfoModel(){}

        public Guid Id { get; set; }
        public string PairCode { get; set; }
        public decimal Amount { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? CellPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public PositionStatus Status { get; set; }
        public PositionType Type { get; set; }
        public decimal? Summary
        {
            get
            {
                if (Status == PositionStatus.Closed)
                {
                    return StatisticDataUtility.CalculateSummary(Amount, BuyPrice.Value, CellPrice.Value, Type);
                }
                return 0;
            }
        }
    }
}