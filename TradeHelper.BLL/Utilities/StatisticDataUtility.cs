using System;
using TradeHelper.BLL.Common;

namespace TradeHelper.BLL.Utilities
{
    public static class StatisticDataUtility
    {
        public static decimal CalculateSummary(decimal amount, decimal buy, decimal sell, PositionType positionType)
        {
            if (positionType == PositionType.Long)
            {
                return ((amount * buy - amount * sell) / (amount * buy)) * 100;
            }
            else
            {
                return ((amount * sell - amount * buy) / (amount * sell)) * 100;
            }
        }
    }
}
