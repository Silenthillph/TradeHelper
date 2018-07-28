import { Enums } from "../common/enums" 

export interface ITradeInfo {
    id: string;
    pairCode: string;
    amount: number;
    buyPrice: number;
    sellPrice: number;
    startDate: Date;
    closeDate: Date;
    status: Enums.PositionStatus;
    type: Enums.PositionType;
}

export class TradeInfo implements ITradeInfo {
    constructor(item?: ITradeInfo){
        if(!item){
            return;
        }
        this.id = item.id;
        this.pairCode = item.pairCode;
        this.amount = item.amount;
        this.buyPrice = item.buyPrice;
        this.sellPrice = item.sellPrice;
        this.startDate = item.startDate;
        this.closeDate = item.closeDate;
        this.status = item.status;
        this.type = item.type;
    }
    

    id: string;    
    pairCode: string;
    amount: number;
    buyPrice: number;
    sellPrice: number;
    startDate: Date;
    closeDate: Date;
    status: Enums.PositionStatus = Enums.PositionStatus.Open;
    type: Enums.PositionType;
    usdSize: number;
    summary: string;
    currentStatus: string;
}