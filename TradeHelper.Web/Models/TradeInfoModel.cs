﻿using System;
using TradeHelper.BLL.Common;

namespace TradeHelper.Web.Models
{
    public class TradeInfoModel
    {
        public Guid Id { get; set; }
        public string PairCode { get; set; }
        public decimal Amount { get; set; }
        public decimal? BuyPrice { get; set; }
        public decimal? CellPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public PositionStatus Status { get; set; }
        public PositionType Type { get; set; }
    }
}