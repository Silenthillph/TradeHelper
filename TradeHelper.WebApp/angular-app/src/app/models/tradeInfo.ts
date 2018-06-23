import { Enums } from "../common/enums" 

export interface ITradeInfo {
    id: string;
    pairCode: string;
    amount: number;
    buyPrice: number;
    cellPrice: number;
    startDate: Date;
    closeDate: Date;
    status: Enums.PositionStatus;
    type: Enums.PositionType;
    summary: number;
}