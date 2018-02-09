import { Enums } from "../common/enums" 

export interface ITradeInfo {
    Id: number;
    PairCode: string;
    Amount: number;
    BuyPrice: number;
    CellPrice: number;
    StartDate: Date;
    CloseDate: Date;
    Status: Enums.PositionStatus;
    Type: Enums.PositionType;
}