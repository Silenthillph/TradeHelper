import { Enums } from "../common/enums" 

export interface ITradeInfo {
    Id: string;
    PairCode: string;
    Amount: number;
    BuyPrice: number;
    CellPrice: number;
    StartDate: Date;
    CloseDate: Date;
    Status: Enums.PositionStatus;
    Type: Enums.PositionType;
}